/*
 *		Description : 消息处理中心  , 只负责发送消息 , 不处理消息
 *		
 *		              需要向什么模块传递信息 , 就 AddComponent 哪个 Manager 脚本
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

public class MessageCenter : MonoBehaviour
{

    public static MessageCenter Instance;

    private void Awake()
    {
        Instance = this;

        // 需要向什么模块传递信息 , 就 AddComponent 哪个 Manager 脚本
        gameObject.AddComponent<UIManager>();

        gameObject.AddComponent<GameManager>();

        DontDestroyOnLoad(gameObject);

    }

    public void Dispatch(MessageBase msg)
    {
        AreaCode areaCode = msg.GetMessageID();
        switch (areaCode)
        {
            case AreaCode.UIManager:
                UIManager.Instance.ExcutingMessage(msg);
                break;
            case AreaCode.GameManager:
                GameManager.Instance.ExcutingMessage(msg);
                break;
            case AreaCode.AudioManager:
                break;
            case AreaCode.NPCManager:
                break;
            case AreaCode.CharacterManager:
                break;
            case AreaCode.NetManager:
                break;
            case AreaCode.AssetManager:
                break;
            default:
                break;
        }
    }

	 
}
