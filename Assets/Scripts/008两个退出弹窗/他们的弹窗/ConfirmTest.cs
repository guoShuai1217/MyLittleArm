/*
 *		Description : 
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmTest : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ConfirmboxObject obj = new ConfirmboxObject("提示", "确定退出吗?", "确定", "取消");
            ConfirmboxAction action = new ConfirmboxAction(ClickYES,ClickNO);
            ConfirmboxView.instance.UsePublicWindow(action, obj);
        }
    }

    private void ClickNO()
    {
        Debug.Log("取消是个好选择");
    }

    private void ClickYES()
    {
        Debug.LogError("退出成功");
    }
}
