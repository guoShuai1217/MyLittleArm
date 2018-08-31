/*
 *		Description : 我的弹框测试 
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08.30
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyExitTest : MonoBehaviour
{


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ExitPanel.Instance.ShowContent("标题", "老铁,确定退出吗?", ClcikYes, ClickNo);
        }
    }

    void ClcikYes()
    {
        Debug.LogError("退出成功!");
    }

    void ClickNo()
    {
        Debug.Log("再玩一会吧..");
    }



}
