/*
 *		Description : 箱子本身
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08.29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
    public System.Action countReduce; // 数量减少的委托

    /// <summary>
    /// 销毁自身
    /// </summary>
    public void DestroySelf()
    {
        if (countReduce != null)
            countReduce();
        Destroy(gameObject);
    }


	 
}
