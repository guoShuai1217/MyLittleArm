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
    public class CubeReceiver : GameBase
    {

        private void Awake()
        {
            msgId = new ushort[]
            {
                (ushort)GameEvent.CHANG_COLOR
            };

            RegistSelf(this, msgId);
        }


        public override void ExcutingMessage(MessageBase msg)
        {
            switch (msg.msgId)
            {
                case (ushort)GameEvent.CHANG_COLOR:
                    GetComponent<MeshRenderer>().material.color = (Color)msg.info;
                    break;
                default:
                    break;
            }
        }











    }
     
}