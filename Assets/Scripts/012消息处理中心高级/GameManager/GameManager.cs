/*
 *		Description : 
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.09
 */
using NotificationSenior;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace NotificationSenior
{
    public class GameManager : ManagerBase
    {

        public static GameManager Instance;

        private void Awake()
        {
            Instance = this;
        }


        public void Dispatch(MessageBase msg)
        {
            if (msg.GetMessageID() == AreaCode.GameManager)
                ExcutingMessage(msg);
            else
                MessageCenter.Instance.Dispatch(msg);
        }

 

    }
}