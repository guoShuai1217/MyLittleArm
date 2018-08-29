/*
 *		Description : ���ⲿѡ��ͼƬ�ӵ�unityָ���ļ�����
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
    private Texture2D originalTex; // ѡ���ͼƬ
    private List<Sprite> sprites = new List<Sprite>();
    public void GetPather() // ����ͼƬ
    {
        OpenFileName openFileName = new OpenFileName();
        openFileName.structSize = Marshal.SizeOf(openFileName);
        openFileName.filter = "ͼƬ�ļ�(*.jpg,*.png,*.bmp)\0*.jpg;*.png;*.bmp";
        openFileName.file = new string(new char[256]);
        openFileName.maxFile = openFileName.file.Length;
        openFileName.fileTitle = new string(new char[64]);
        openFileName.maxFileTitle = openFileName.fileTitle.Length;
        if (texPath == null)
        {
            openFileName.initialDir = Application.streamingAssetsPath.Replace('/', '\\');//Ĭ��·��
        }
        else
        {
            openFileName.initialDir = texPath;
        }
        openFileName.title = "ѡ��ͼƬ";
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
    /// �ļ�������ͼƬ
    /// </summary>
    public IEnumerator FileStreamLoadTexture(string path, string name)
    {
        //ͨ��·�����ر���ͼƬ
        var fileType = Path.GetExtension(name);

        if (fileType == ".bmp")
        {
           // PublicWindowOne.instance.showView("��ʾ", "�ݲ�֧��bmp��ʽ�ļ���", "ȷ��");
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
                Debug.Log("Texture���ڵ�����Textureʧ��");
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
                        Debug.Log("�Ѵ��� ");
                        exist = true;
                      //  PublicWindowOne.instance.showView("��ʾ", "����ӹ���ͼƬ���벻Ҫ�ظ���ӡ�", "ȷ��");
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
                //TipsWindow.instance.AutoShowText("�ɹ����ͼƬ��");
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
