/*
 *		Description : UI 模块的基类
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.09.08
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NotificationSenior
{
    public class UIBase : MonoBase
    {

        public ushort[] msgId;

        /// <summary>
        /// 注册自己
        /// </summary>
        /// <param name="mono"></param>
        /// <param name="msgs"></param>
        public void RegistSelf(MonoBase mono,params ushort[] msgs)
        {
            UIManager.Instance.RegistMessage(mono, msgs);
        }

        /// <summary>
        /// 注销自己
        /// </summary>
        /// <param name="mono"></param>
        /// <param name="msgs"></param>
        public void UnRegistSelf(MonoBase mono, params ushort[] msgs)
        {
            UIManager.Instance.UnRegistMessage(mono, msgs);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        public void Dispatch(MessageBase msg)
        {
            UIManager.Instance.Dispatch(msg);
        }

        private void OnDestroy()
        {
            if (msgId != null)
            {
                UnRegistSelf(this, msgId);
            }
        }

 
        public override void ExcutingMessage(MessageBase msg)
        {
             
        }
    }
}