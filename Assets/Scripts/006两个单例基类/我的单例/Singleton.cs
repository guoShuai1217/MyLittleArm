/*
 *		Description : 脚本式单例
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08.29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Singleton<T> :IDisposable where T :new ()
{

    private static T instance;

    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }

    public virtual void Dispose()
    {
         // 内存处理的善后工作
    }
}
