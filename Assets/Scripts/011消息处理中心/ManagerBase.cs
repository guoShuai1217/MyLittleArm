/*
 *		Description : 管理基类 , 所有管理器都要继承这个基类
 *		
 *		               负责消息的注册 , 注销 , 处理自身的消息
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.09.06
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NotificationJunior
{
    public class ManagerBase : MonoBase
    {

        public Dictionary<ushort, List<MonoBase>> dic = new Dictionary<ushort, List<MonoBase>>();


        /// <summary>
        /// 处理自身的消息
        /// </summary>
        /// <param name="EventCode"></param>
        /// <param name="message"></param>
        public override void ExcuteMessage(ushort EventCode, object message)
        {
            if (!dic.ContainsKey(EventCode))
            {
                Debug.LogError("不存在该事件");
                return;
            }

            List<MonoBase> monoList = dic[EventCode];
            foreach (MonoBase item in monoList)
            {
                item.ExcuteMessage(EventCode, message);
            }
        }


        /// <summary>
        /// 注册单个消息
        /// </summary>
        /// <param name="EventCode"></param>
        /// <param name="mono"></param>
        public void RegistMessage(ushort EventCode, MonoBase mono)
        {
            List<MonoBase> list;
            if (!dic.ContainsKey(EventCode))
            {
                list = new List<MonoBase>();
                list.Add(mono);
                dic.Add(EventCode, list);
                return;
            }

            list = dic[EventCode];
            list.Add(mono);

        }

        /// <summary>
        /// 注册多个消息
        /// </summary>
        /// <param name="eventCode"></param>
        /// <param name="mono"></param>
        public void RegistMessage(ushort[] eventCode, MonoBase mono)
        {
            for (int i = 0; i < eventCode.Length; i++)
            {
                RegistMessage(eventCode[i], mono);
            }
        }


        /// <summary>
        /// 注销单个事件
        /// </summary>
        /// <param name="eventCode"></param>
        /// <param name="mono"></param>
        public void UnRegistMessage(ushort eventCode, MonoBase mono)
        {

            if (!dic.ContainsKey(eventCode))
            {
                Debug.LogError("不用注销,因为压根就没有");
                return;
            }

            List<MonoBase> list = dic[eventCode];
            if (list.Contains(mono))
            {
                list.Remove(mono);

                if (list.Count == 0)
                    dic.Remove(eventCode);
            }

        }


        /// <summary>
        /// 注销多个事件
        /// </summary>
        /// <param name="eventCode"></param>
        /// <param name="mono"></param>
        public void UnRegistMessage(ushort[] eventCode, MonoBase mono)
        {
            for (int i = 0; i < eventCode.Length; i++)
            {
                UnRegistMessage(eventCode[i], mono);
            }
        }







    }
}