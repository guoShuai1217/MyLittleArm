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
    public class Sender : UIBase
    {

        public void OnClickBtn()
        {
            Dispatch(new MessageBase((ushort)UIEvent.OPEN_PANEL2));

            Dispatch(new MessageBase((ushort)GameEvent.CHANG_COLOR,Color.cyan));
        }

       
    }
}