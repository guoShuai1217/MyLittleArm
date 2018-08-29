/*
 *		Description :  父池子[管理所有子池子]
 *		
 *		               外部调用都是通过这个脚本,这个脚本再去调子池子
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoolController : MonoSingleton<PoolController>
{
    private Dictionary<string, SubPool> poolDic = new Dictionary<string, SubPool>();

    /// <summary>
    /// 出池子
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public GameObject Spawn(string name)
    {
        if (!poolDic.ContainsKey(name))
        {
            CreatePool(name);
        }

        return poolDic[name].Spawn();
    }

    /// <summary>
    /// 入池子
    /// </summary>
    /// <param name="obj"></param>
    public void UnSpawn(GameObject obj)
    {
        foreach (SubPool item in poolDic.Values)
        {
            if (item.IsContainsObj(obj))
            {
                item.UnSpawn(obj);
                break;
            }
        }
    }

    /// <summary>
    /// 回收所有
    /// </summary>
    public void UnSpawnAll()
    {
        foreach (SubPool item in poolDic.Values)
        {
            item.UnSpawnAll();
        }
    }



    /// <summary>
    /// 创建新池子 
    /// </summary>
    /// <param name="name"></param>
    private void CreatePool(string name)
    {
        GameObject obj = Resources.Load<GameObject>("Prefabs/" + name);
        SubPool sub = new SubPool(obj);
        poolDic.Add(sub.prefabName, sub);
    }
}
