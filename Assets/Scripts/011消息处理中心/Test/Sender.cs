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

public class Sender : UIBase
{

    public void OnClickBtn()
    {
        Dispatch(AreaCode.UI, UIEvent.OPEN_Panel2,  true);
    }





}
