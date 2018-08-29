/*
 *		Description : 子池子
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08.29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubPool  
{
    /// <summary>
    /// 子池子
    /// </summary>
    private List<GameObject> subList = new List<GameObject>();

    /// <summary>
    /// 可放入对象池的对象
    /// </summary>
    private GameObject m_Prefab;

    /// <summary>
    /// 返回对象的名字
    /// </summary>
    public string prefabName
    {
        get
        {
            return m_Prefab.name;
        }
    }

    public SubPool(GameObject obj)
    {
        m_Prefab = obj;
    }

    /// <summary>
    /// 出池子
    /// </summary>
    /// <returns></returns>
    public GameObject Spawn()
    {
        GameObject obj = null;
        foreach (GameObject item in subList)
        {
            if (!item.activeSelf)
            {
                obj = item;
                break;
            }               
        }

        if(obj == null)
        {
            obj = GameObject.Instantiate(m_Prefab);
            subList.Add(obj);
        }

        obj.SetActive(true);
        IResuable ir = obj.GetComponent<IResuable>();

        if (ir != null)
            ir.Spawn();

        return obj;
    }

    /// <summary>
    /// 入池子
    /// </summary>
    /// <param name="obj"></param>
    public void UnSpawn(GameObject obj)
    {
        if (subList.Contains(obj))
        {
            
            IResuable ir = obj.GetComponent<IResuable>();

            if (ir != null)
                ir.UnSpawn();

            obj.SetActive(false);
        }
    }


    /// <summary>
    /// 回收所有
    /// </summary>
    public void UnSpawnAll()
    {
        foreach (GameObject item in subList)
        {
            if (item.activeSelf)
                UnSpawn(item);
        }
    }

    /// <summary>
    /// 是否包含该对象
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public bool IsContainsObj(GameObject obj)
    {
        return subList.Contains(obj);
    }
	 
}
