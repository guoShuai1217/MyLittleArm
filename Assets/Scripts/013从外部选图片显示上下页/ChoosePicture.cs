/*
 *		Description : 
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.09
 */
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePicture : MonoBehaviour
{

    public Button nextBtn;

    public Button lastBtn;

    public Button choosePictureBtn;

    public Image imag;

    public int maxCount = 5; // 最多几张图片


    private string texPath;  // 图片的路径 在选择时获得
    private string texName; // 选择到的图片的名字
    private List<Sprite> sprites = new List<Sprite>();
    private Texture2D originalTex; // 选择的图片
    private Sprite ss;

    int int_num = 0;
    public Text text_Page; // 显示第几页

    private void Start()
    {
        int_num = 0;
        text_Page.text = string.Format("第{0}张", int_num + 1);

        choosePictureBtn.onClick.AddListener(ChooseSprite);
        nextBtn.onClick.AddListener(OnClickNext);
        lastBtn.onClick.AddListener(OnClickLast);


    }

    public void ChooseSprite()
    {
        OpenFileName openFileName = new OpenFileName();
        openFileName.structSize = System.Runtime.InteropServices.Marshal.SizeOf(openFileName);

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
            StartCoroutine(FileStreamLoadTexture(texPath, texName, sprites, "AddTexture"));

            imag.sprite = ss;
        }
        else
        {
            Debug.Log("您没有选择图片..");
        }

    }


    
    /// <summary>
    /// 文件流加载图片
    /// </summary>
    public IEnumerator FileStreamLoadTexture(string path, string name, List<Sprite> spriteList, string namePath)
    {
        //通过路径加载本地图片
        var fileType = Path.GetExtension(name);

        if (fileType == ".bmp")
        {
           // PublicWindowOne.Instance.showView("提示", "暂不支持bmp格式文件。", "确定");
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
            ss = ChangeToSprite(originalTex);

            ss.name = name;
            bool exist = false;
            if (spriteList.Count > 0)
            {
                for (int i = 0; i < spriteList.Count; i++)
                {
                    if (spriteList[i].name.Contains(ss.name))
                    {
                        Debug.Log("已存在 ");
                        exist = true;
                        //PublicWindowOne.Instance.showView("提示", "以添加过该图片，请不要重复添加。", "确定");
                        continue;
                    }
                }
            }
            if (!exist)
            {
                spriteList.Add(ss);
                File.WriteAllBytes(Application.streamingAssetsPath + "/" + namePath + "/" + name /*+ ".png"*/, originalTex.EncodeToPNG());
                // TipsWindow.Instance.AutoShowText("成功添加现场图片。");
                Debug.Log("成功添加图片");

            }
            yield return 0;
        }
    }
    public Sprite ChangeToSprite(Texture2D tex)
    {
        Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
        return sprite;
    }


   

    /// <summary>
    /// 点击下一页
    /// </summary>
    public void OnClickNext()
    {
        imag.sprite = null;

        int_num++;
        text_Page.text = string.Format("第{0}张", int_num + 1);
       
        if(int_num <= maxCount - 1)
        {
            if (sprites.Count -1 >= int_num)
                imag.sprite = sprites[int_num];
        }
        else
        {
            int_num = 0;
            text_Page.text = string.Format("第{0}张", int_num + 1);
            if (sprites.Count - 1 >= int_num)
                imag.sprite = sprites[int_num];
        }
    }


    /// <summary>
    /// 点击上一页
    /// </summary>
    public void OnClickLast()
    {
        
        int_num--;
        text_Page.text = string.Format("第{0}张", int_num + 1);

        if(int_num >= 0)
        {
            if (sprites.Count >= int_num)
                imag.sprite = sprites[int_num];
        }
        else
        {
            int_num = maxCount -1 ;
            text_Page.text = string.Format("第{0}张", int_num + 1);
        }
    }
}
