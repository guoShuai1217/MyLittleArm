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
    public class UIManager : ManagerBase
    {

        public static UIManager Instance;

        private void Awake()
        {
            Instance = this;
        }


        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        public void Dispatch(MessageBase msg)
        {
            // 如果消息 Id 是我 UI模块的 消息范围之内的 , 就自己处理
            if (msg.GetMessageID() == AreaCode.UIManager)
                ExcutingMessage(msg);
            else  // 如果消息 Id 是我 UI模块的 消息范围之内的 , 就交给MsgCenter处理      
                MessageCenter.Instance.Dispatch(msg);
        }

    }
}