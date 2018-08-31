using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmboxView : MonoBehaviour
{

    public static ConfirmboxView instance;

    public GameObject obj_Mask; // 弹窗的界面

    [SerializeField]
    Text text_title;//标题文字

    [SerializeField]
    Text text_content;//内容

    [SerializeField]
    GameObject btn_ok;//确认按钮

    [SerializeField]
    Text text_ok;//确认按钮文字

    [SerializeField]
    GameObject btn_cancel;//取消按钮

    [SerializeField]
    Text text_cancel;//取消按钮文字

    public ConfirmboxAction confirmboxAction;
  

    private void Awake()
    {
        instance = this;
        InitUI();
    }
 
    void InitUI()
    {
        obj_Mask = transform.Find("obj_Mask").gameObject;
        text_title = obj_Mask. transform.Find("bg/background/text_title").GetComponent<Text>();
        text_content = obj_Mask. transform.Find("bg/text_content").GetComponent<Text>();

        btn_ok = obj_Mask. transform.Find("btn_ok").gameObject;
        text_ok =  btn_ok.transform.Find("text_ok").GetComponent<Text>();

        btn_cancel = obj_Mask. transform.Find("btn_cancel").gameObject;
        text_cancel = btn_cancel. transform.Find("text_cancel").GetComponent<Text>();

        btn_ok.GetComponent<Button>().onClick.AddListener(delegate () 
        {
            confirmboxAction.OkAction();
            obj_Mask.SetActive(false);
        });
        btn_cancel.GetComponent<Button>().onClick.AddListener(delegate () 
        {
            confirmboxAction.CancleAction();
            obj_Mask.SetActive(false);
        });

        obj_Mask.SetActive(false);
    }
    /// <summary>
    /// 通用弹窗(两个可自定义按钮的)
    /// </summary>
    /// <param name="action"></param>
    /// <param name="obj"></param>
    public void UsePublicWindow(ConfirmboxAction action, ConfirmboxObject obj)
    {
        if (!obj_Mask.activeSelf)
        {
            obj_Mask.SetActive(true);
        }
        confirmboxAction = action;
        ShowConfirmbox(obj);
    }

    /// <summary>
    /// 显示信息
    /// </summary>
    /// <param name="confirmboxObject"></param>
    public void ShowConfirmbox(ConfirmboxObject confirmboxObject)
    {
        text_title.text = confirmboxObject.Title;
        text_content.text = confirmboxObject.Content;
        text_ok.text = confirmboxObject.Ok;
        text_cancel.text = confirmboxObject.Cancel;
    }
 
}
#region 显示界面消息内容的封装类
/// <summary>
/// 显示界面消息内容的封装类
/// </summary>
public class ConfirmboxObject
{
    string title;
    /// <summary>
    /// 标题
    /// </summary>
    public string Title { get { return title; } }

    string content;
    /// <summary>
    /// 内容
    /// </summary>
    public string Content { get { return content; } }

    string ok;
    /// <summary>
    /// 确认按钮显示文字
    /// </summary>
    public string Ok { get { return ok; } }

    string cancel;
    /// <summary>
    /// 取消按钮显示文字
    /// </summary>
    public string Cancel { get { return cancel; } }


    public ConfirmboxObject(string title, string content, string ok, string cancel)
    {
        this.title = title;
        this.content = content;
        this.ok = ok;
        this.cancel = cancel;
    }
}
#endregion

/// <summary>
/// 委托类
/// </summary>
public class ConfirmboxAction
{
    //确认委托
    System.Action okAction;
    public System.Action OkAction { get { return okAction; } }
    //取消委托
    System.Action cancleAction;
    public System.Action CancleAction { get { return cancleAction; } }

    public ConfirmboxAction(System.Action okAction, System.Action cancleAction)
    {
        this.okAction = okAction;
        this.cancleAction = cancleAction;
    }
}