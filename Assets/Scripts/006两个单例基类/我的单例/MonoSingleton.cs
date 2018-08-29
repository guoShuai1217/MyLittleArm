/*
 *		Description : 组件式单例
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08.29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonoSingleton<T> : MonoBehaviour where T:MonoBehaviour
{

    private static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject obj = new GameObject(typeof(T).Name);
                instance = obj.AddComponent<T>();
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        instance = this as T;
    }


	 
}
