/*
 *		Description : 
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceController :Singleton<ResourceController>
{

    /// <summary>
    /// 加载方法
    /// enumName 是传进来的枚举值
    /// enumType 是枚举值enumName的类型
    /// filePath 是对应的加载路径
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="enumName">枚举名</param>
    /// <returns></returns>
    public T LoadObject<T>(object enumName) where T :Object
    {
        string filePath = string.Empty;
        string enumType = enumName.GetType().Name; // 获取加载的音频的枚举名字

        switch (enumType)
        {
            case "Music_Main":
                filePath = "Main/" + enumName.ToString(); // 找Resources下的 Main 下的音频名字
                break;
            case "Music_Effect":
                filePath = "EffectMusic/" + enumName.ToString(); // 找Resources下的 EffectMusic 下的音频名字
                break;
            case "Music_Dialog":
                filePath = "Dialog/" + enumName.ToString(); // 找Resources下的 Dialog 下的音频名字
                break;
            default:
                Debug.LogError("不存在该枚举类型" + enumType.ToString());
                break;             
        }

        return Resources.Load<T>(filePath);
    }


	 
}
