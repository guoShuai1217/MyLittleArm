/*
 *		Description : UI模块的基类 负责消息的绑定和解绑
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.09.06
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBase : MonoBase
{

    public List<ushort> msgList = new List<ushort>();

    /// <summary>
    /// 绑定消息
    /// </summary>
    /// <param name="eventCode"></param>
    public void BindMessage(params ushort[] eventCode)
    {
        msgList.AddRange(eventCode);
        UIManager.Instance.RegistMessage(msgList.ToArray(), this);
    }

    /// <summary>
    /// 解绑消息
    /// </summary>
    public void UnBindMessage()
    {
        UIManager.Instance.RegistMessage(msgList.ToArray(), this);
    }

    /// <summary>
    /// 物体销毁时自动解绑消息
    /// </summary>
    public virtual void OnDestroy()
    {
        if (msgList != null)
            UnBindMessage();
    }

    /// <summary>
    /// 发消息
    /// </summary>
    /// <param name="areaCode"></param>
    /// <param name="eventCode"></param>
    /// <param name="message"></param>
    public void Dispatch(ushort areaCode, ushort eventCode, object message)
    {
        MsgCenter.Instance.Dispatch(areaCode, eventCode, message);
    }


    // 这里其实并不需要去实现这个方法
    public override void ExcuteMessage(ushort EventCode, object message)
    {
         
    }
}
