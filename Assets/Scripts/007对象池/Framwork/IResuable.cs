/*
 *		Description : 对象池管理对象的接口 
 *		
 *		              子弹,小怪等,必须继承这个接口才可以使用对象池
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08.29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IResuable  
{

    void Spawn();

    void UnSpawn();
 
}
