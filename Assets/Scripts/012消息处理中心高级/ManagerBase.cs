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
    /// <summary>
    /// 节点类
    /// </summary>
    public class EventNode
    {
        public MonoBase mono;

        public EventNode next;

        public EventNode(MonoBase mono)
        {
            this.mono = mono;
            next = null;
        }
    }

    public class ManagerBase : MonoBase
    {

        public Dictionary<ushort, EventNode> msgDic = new Dictionary<ushort, EventNode>();

        /// <summary>
        /// 实现抽象类
        /// </summary>
        public override void ExcutingMessage(MessageBase msg)
        {
            if (!msgDic.ContainsKey(msg.msgId))
            {
                Debug.LogError("不存在该ID , " + msg.GetMessageID() + "出的问题");
                return;
            }

            EventNode node = msgDic[msg.msgId];

            do
            {
                // 通过 msg.msgId 找到对应的链表 , 全部通知
                // 链表里注册了 msg.msgId 这个消息的 mono , 都要执行这个方法
                node.mono.ExcutingMessage(msg);
                node = node.next;

            } while (node != null);

        }


        #region 注册消息

        /// <summary>
        /// 注册单个消息
        /// </summary>
        /// <param name="msgId">消息ID</param>
        /// <param name="node"></param>
        public void RegistMessage(ushort msgId , EventNode node )
        {
            if (!msgDic.ContainsKey(msgId))
            {
                msgDic.Add(msgId, node);
            }
            else
            {
                EventNode tempNode = msgDic[msgId];
                while (tempNode.next != null)
                {
                    tempNode = tempNode.next;
                }

                tempNode.next = node;
            }
        }

        /// <summary>
        /// 注册多个消息
        /// </summary>
        /// <param name="mono"></param>
        /// <param name="msgs"></param>
        public void RegistMessage( MonoBase mono, params ushort[] msgs)
        {
            for (int i = 0; i < msgs.Length; i++)
            {
                RegistMessage(msgs[i] , new EventNode(mono));
            }
        }





        #endregion


        #region 注销消息

        /// <summary>
        /// 注销单个消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="mono"></param>
        public void UnRegistMessage(ushort msg, MonoBase mono)
        {
            if (!msgDic.ContainsKey(msg))
            {
                Debug.LogError("该ID没有注册, 无法注销");
                return;
            }
            // 存在的话 , 有三种情况:
           
            EventNode tempNode = msgDic[msg];

            //  1. 在头部
            if (tempNode.mono == mono)
            {
                if (tempNode.next != null) // 头部后面还有
                {
                    msgDic[msg] = tempNode.next;
                    tempNode.next = null;                  
                }
                else // 就一个头 , 删了头就没了
                {
                    msgDic.Remove(msg);
                }
               
            }
            else
            {
                // 2. 在中部或者在尾部
                while (tempNode.next != null && tempNode.next.mono != mono)
                {
                    tempNode = tempNode.next;
                }

                if (tempNode.next.next != null) // 中间
                {
                    EventNode currentNode = tempNode.next;
                    tempNode.next = currentNode.next;
                    currentNode.next = null;
                }
                else // 尾部
                {
                    tempNode.next = null;
                }

            }

        }

        /// <summary>
        /// 注销多个消息
        /// </summary>
        /// <param name="mono"></param>
        /// <param name="msgs"></param>
        public void UnRegistMessage(MonoBase mono , params ushort[] msgs)
        {
            for (int i = 0; i < msgs.Length; i++)
            {
                UnRegistMessage(msgs[i], mono);
            }
        }



        #endregion

 
    }
}