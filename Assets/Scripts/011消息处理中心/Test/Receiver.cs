/*
 *		Description : 消息接收者
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.09.06
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Receiver : UIBase
{
    [SerializeField]
    private GameObject ima;

    private void Awake()
    {
        BindMessage(UIEvent.OPEN_Panel2);
        ima.SetActive(false);
    }


    public override void ExcuteMessage(ushort EventCode, object message)
    {
        switch (EventCode)
        {
            case UIEvent.OPEN_Panel2:
                ima.SetActive((bool)message);
                break;
            default:
                break;
        }
    }







}
