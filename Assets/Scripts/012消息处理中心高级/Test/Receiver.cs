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
    public class Receiver : UIBase
    {

        public GameObject ima;

        private void Awake()
        {
            msgId = new ushort[]
            {
                (ushort)UIEvent.OPEN_PANEL2
            };

            RegistSelf(this, msgId);
            ima.SetActive(false);
        }

        public override void ExcutingMessage(MessageBase msg)
        {
            switch (msg.msgId)
            {
                case (ushort)UIEvent.OPEN_PANEL2:
                    ima.SetActive(true);
                    break;
                default:
                    break;
            }
        }




    }
}