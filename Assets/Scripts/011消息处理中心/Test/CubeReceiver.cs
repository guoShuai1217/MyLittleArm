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
    public class CubeReceiver : CharacterBase
    {

        private void Awake()
        {
            BindMsg(CharacterEvent.CHANG_SCALE);
        }

        public override void ExcuteMessage(ushort EventCode, object message)
        {
            switch (EventCode)
            {
                case CharacterEvent.CHANG_SCALE:
                    transform.localScale = Vector3.one * (float)message;
                    break;
                default:
                    break;
            }
        }

    }
}