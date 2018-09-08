/*
 *		Description : 消息发送者
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
    public class Sender : UIBase
    {

        public void OnClickBtn()
        {
            Dispatch(AreaCode.UI, UIEvent.OPEN_Panel2, true); // 给Panel2发送显示 ima 的消息
            Dispatch(AreaCode.CHARACTER, CharacterEvent.CHANG_SCALE, 1.5f);  // 给 cube 发送改变大小的消息
        }





    }
}