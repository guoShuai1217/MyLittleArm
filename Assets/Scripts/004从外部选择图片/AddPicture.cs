/*
 *		Description : 从外部选择图片加到unity指定文件夹里
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08.21
 */
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AddPicture : MonoBehaviour
{
    string texPath;
    private string texName;
    private Texture2D originalTex; // 选择的图片
    private List<Sprite> sprites = new List<Sprite>();
    public void GetPather() // 加载图片
    {
        OpenFileName openFileName = new OpenFileName();
        openFileName.structSize = Marshal.SizeOf(openFileName);
        openFileName.filter = "图片文件(*.jpg,*.png,*.bmp)\0*.jpg;*.png;*.bmp";
        openFileName.file = new string(new char[256]);
        openFileName.maxFile = openFileName.file.Length;
        openFileName.fileTitle = new string(new char[64]);
        openFileName.maxFileTitle = openFileName.fileTitle.Length;
        if (texPath == null)
        {
            openFileName.initialDir = Application.streamingAssetsPath.Replace('/', '\\');//默认路径
        }
        else
        {
            openFileName.initialDir = texPath;
        }
        openFileName.title = "选择图片";
        openFileName.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000008;

        if (LocalDialog.GetSaveFileName(openFileName))
        {
            texPath = openFileName.file;
            Debug.Log(texPath);
            texName = openFileName.fileTitle;
            StartCoroutine(FileStreamLoadTexture(texPath, texName));
        }
    }
    /// <summary>
    /// 文件流加载图片
    /// </summary>
    public IEnumerator FileStreamLoadTexture(string path, string name)
    {
        //通过路径加载本地图片
        var fileType = Path.GetExtension(name);

        if (fileType == ".bmp")
        {
           // PublicWindowOne.instance.showView("提示", "暂不支持bmp格式文件。", "确定");
        }
        else
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            fs.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[fs.Length];

            fs.Read(buffer, 0, buffer.Length);
            fs.Close();
            fs.Dispose();
            originalTex = new Texture2D(2, 2);
            var iSLoad = originalTex.LoadImage(buffer);
            originalTex.Apply();
            if (!iSLoad)
            {
                Debug.Log("Texture存在但生成Texture失败");
            }
            Sprite ss = ChangeToSprite(originalTex);

            ss.name = name;
            bool exist = false;
            if (sprites.Count > 0)
            {
                for (int i = 0; i < sprites.Count; i++)
                {
                    if (sprites[i].name.Contains(ss.name))
                    {
                        Debug.Log("已存在 ");
                        exist = true;
                      //  PublicWindowOne.instance.showView("提示", "以添加过该图片，请不要重复添加。", "确定");
                        continue;
                    }
                }
            }
            if (!exist)
            {
                sprites.Add(ss);
                string outPath = Application.streamingAssetsPath + "/AddTexture/";
                if (!Directory.Exists(outPath))
                    Directory.CreateDirectory(outPath);
                File.WriteAllBytes(outPath + name /*+ ".png"*/, originalTex.EncodeToPNG());
                AssetDatabase.Refresh();
                //TipsWindow.instance.AutoShowText("成功添加图片。");
            }
            yield return 0;
        }
    }
    private Sprite ChangeToSprite(Texture2D tex)
    {
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        return sprite;
    }



}
