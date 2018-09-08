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
    public class MessageBase  
    {

        public  ushort msgId = 0;

        public object info;

      
        public MessageBase(ushort msgId)
        {
            this.msgId = msgId;           
        }

        public MessageBase(ushort msgId , object info)
        {
            this.msgId = msgId;
            this.info = info;
        }
      
        
        /// <summary>
        /// 获取消息ID,判断消息属于哪个模块
        /// </summary>
        /// <returns></returns>
        public AreaCode GetMessageID()
        {
            //  3005/3000 = 1 , 1 * msgSpan = 3000 , 属于 GameManager
            int id = msgId / FrameTool.msgSpan;
            return ((AreaCode)(id * FrameTool.msgSpan));
        }


    }
}