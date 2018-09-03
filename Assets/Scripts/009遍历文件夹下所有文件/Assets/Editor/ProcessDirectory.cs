/*
 *		Description : 遍历文件夹
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08.31
 */
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ProcessDirectory 
{
    [MenuItem("Shuai/遍历文件夹")]
    private static void ProcessFileSystemInfo()
    {
        // 初始文件夹
        string outPath = Application.streamingAssetsPath + "/" + "009遍历文件夹下所有文件/";

        if (!Directory.Exists(outPath))
            Directory.CreateDirectory(outPath);

        DirectoryInfo directoryInfo = new DirectoryInfo(outPath);
        DirectoryInfo[] dirs =  directoryInfo.GetDirectories();

        foreach (DirectoryInfo item in dirs)
        {
            string subPath = outPath + "/" + item.Name; // 第一集目录文件
            if(subPath == null)
            {
                Debug.LogError("该路径不存在" + subPath);
                return;
            }

            DirectoryInfo subDirect = new DirectoryInfo(subPath);
          
            Dictionary<string, string> nameDic = new Dictionary<string, string>();
            int index = subPath.LastIndexOf('/');
            string sceneName = subPath.Substring(index+1);
            Debug.Log(sceneName);

            SubProcess(subDirect, nameDic); 
            OnWriteDic(sceneName, nameDic);
        }
        AssetDatabase.Refresh();
        Debug.Log("生成成功,牛逼");
    }

    /// <summary>
    /// 遍历每一个子级的所有文件系统
    /// </summary>
    /// <param name="fileSystemInfo"></param>
    /// <param name="nameDic"></param>
    private static void SubProcess(FileSystemInfo fileSystemInfo,Dictionary<string,string> nameDic)
    {
        if (!fileSystemInfo.Exists)
        {
            Debug.Log("该文件不存在");
            return;
        }

        DirectoryInfo directoryInfo = fileSystemInfo as DirectoryInfo;
        FileSystemInfo[] dirs = directoryInfo.GetFileSystemInfos();

        foreach (FileSystemInfo item in dirs)
        {
            FileInfo file = item as FileInfo;

            if (file != null )
            {
                if (file.Extension != ".meta")
                    nameDic.Add(file.Name, directoryInfo.FullName);             
            }
            else
                SubProcess(item, nameDic);

        }


    }

    /// <summary>
    /// 写入txt文件
    /// </summary>
    /// <param name="sceneName"></param>
    /// <param name="nameDic"></param>
    private static void OnWriteDic(string sceneName,Dictionary<string,string>nameDic)
    {
        string filePath = Application.dataPath + "/Scenes/009遍历文件夹下所有文件/ " + sceneName + ".txt";

        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(nameDic.Count);
                foreach (string item in nameDic.Keys)
                {
                    sw.WriteLine(item.Split('.')[0].ToString() + ",");
                }
            }
        }

    }
}
