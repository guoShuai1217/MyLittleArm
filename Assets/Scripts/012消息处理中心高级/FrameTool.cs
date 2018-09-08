/*
 *		Description : 框架工具类 
 *		
 *		               封装一些常用的API
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.09.08
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NotificationSenior
{
    public class FrameTool  
    {

        public const int msgSpan = 3000;

    }

    public enum AreaCode
    {
        UIManager = 0,

        GameManager = FrameTool.msgSpan,

        AudioManager = FrameTool.msgSpan * 2,

        NPCManager = FrameTool.msgSpan * 3,

        CharacterManager = FrameTool.msgSpan * 4,

        NetManager = FrameTool.msgSpan * 5,

        AssetManager = FrameTool.msgSpan * 6
    }

}