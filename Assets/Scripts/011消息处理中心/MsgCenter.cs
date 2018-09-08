/*
 *		Description : 消息处理中心  
 *		
 *		              只负责发送消息
 *		              
 *		              发送消息的管理器一定要Add上 (例如 Add UIManager), 而且这个脚本要先执行
 *		              
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
    public class MsgCenter : MonoBehaviour
    {
        public static MsgCenter Instance;

        private void Awake()
        {
            Instance = this;

            // 加上需要的组件
            gameObject.AddComponent<UIManager>();
            gameObject.AddComponent<CharacterManager>();
            DontDestroyOnLoad(gameObject);
        }


        /// <summary>
        /// 发送消息 , 所有的发消息,都要通过这个方法
        /// </summary>
        /// <param name="areaCode">区域码</param>
        /// <param name="eventCode">事件码</param>
        /// <param name="message"> 传递的消息参数 </param>>
        public void Dispatch(ushort areaCode, ushort eventCode, object message)
        {
            switch (areaCode)
            {
                case AreaCode.UI:
                    UIManager.Instance.ExcuteMessage(eventCode, message);
                    break;
                case AreaCode.GAME:
                    break;
                case AreaCode.CHARACTER:
                    CharacterManager.Instance.ExcuteMessage(eventCode, message);
                    break;
                case AreaCode.AUDIO:
                    // AudioManager.Instance.ExcuteMessage(eventCode, message);
                    break;
                case AreaCode.NET:
                    break;
                case AreaCode.SCENE:
                    break;
                default:
                    break;
            }
        }

    }
}