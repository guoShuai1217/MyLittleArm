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

namespace NotificationJunior
{
    public class CharacterBase : MonoBase
    {


        public List<ushort> msgList = new List<ushort>();


        public void BindMsg(params ushort[] eventCode)
        {
            msgList.AddRange(eventCode);
            CharacterManager.Instance.RegistMessage(msgList.ToArray(), this);
        }


        public void UnBlindMsg()
        {
            CharacterManager.Instance.UnRegistMessage(msgList.ToArray(), this);
        }

        public virtual void OnDestroy()
        {
            UnBlindMsg();
        }

        public void Dispatch(ushort areaCode, ushort eventCode, object message)
        {
            if (areaCode == AreaCode.CHARACTER)
                CharacterManager.Instance.ExcuteMessage(eventCode, message);
            else
                MsgCenter.Instance.Dispatch(areaCode, eventCode, message);
        }



        public override void ExcuteMessage(ushort EventCode, object message)
        {
             
        }
    }
}