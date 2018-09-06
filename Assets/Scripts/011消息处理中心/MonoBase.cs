/*
 *		Description : 基类
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.09.06
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MonoBase : MonoBehaviour
{

    public abstract void ExcuteMessage(ushort EventCode , object message);
	 
}
