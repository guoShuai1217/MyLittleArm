/*
 *		Description : 
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.09
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace NotificationSenior
{
    public class GameBase : MonoBase
    {

        public ushort[] msgId;


        public void RegistSelf(MonoBase mono , params ushort[] msgs)
        {
            GameManager.Instance.RegistMessage(mono, msgs);
        }


        public void UnRegistSelf(MonoBase mono, params ushort[] msgs)
        {
            GameManager.Instance.UnRegistMessage(mono, msgs);
        }

        public void Dispatch(MessageBase msg)
        {
            GameManager.Instance.Dispatch(msg);
        }

        private void OnDestroy()
        {
            if (msgId.Length != 0)
                UnRegistSelf(this, msgId);
        }






        public override void ExcutingMessage(MessageBase msg)
        {
             
        }
    }
}