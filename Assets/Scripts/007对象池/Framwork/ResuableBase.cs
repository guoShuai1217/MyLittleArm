/*
 *		Description :  基类
 *		
 *		               此类实现接口没有意义,应该是小怪,子弹继承接口
 *		               
 *		               因此我们把此类改成抽象类
 *		
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08.29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ResuableBase : MonoBehaviour, IResuable
{
    public abstract void Spawn();


    public abstract void UnSpawn();

}
