/*
 *		Description : 我的退出弹框
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08。30
 */
using RTEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void ClickYesButton();

public delegate void ClickNoButton();

public class ExitPanel : MonoBehaviour
{
    public static ExitPanel Instance;

    private Text title; // 标题

    private Text content; // 内容

    private Button btn_yes; // 确定按钮

    private Button btn_no; // 取消按钮

    private Button btn_cancel; // 点击弹窗外面的地方,也会取消

    public ClickYesButton yesAction; // 确定回调

    public ClickNoButton noAction; // 取消回调

    private void Awake()
    {       
        Instance = this;

        title = transform.Find("BackGround/Title").GetComponent<Text>();
        content = transform.Find("BackGround/content").GetComponent<Text>();
        btn_yes = transform.Find("BackGround/btn_yes").GetComponent<Button>();
        btn_no = transform.Find("BackGround/btn_no").GetComponent<Button>();
        btn_cancel = transform.Find("btn_cancel").GetComponent<Button>();

        btn_yes.onClick.AddListener(OnClickYesBtn);

        btn_no.onClick.AddListener(OnClickNoBtn);

        btn_cancel.onClick.AddListener(() => { gameObject.SetActive(false); });
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 点击确定按钮
    /// </summary>
    private void OnClickYesBtn()
    {
        if (yesAction != null)
            yesAction();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 点击取消按钮
    /// </summary>
    private void OnClickNoBtn()
    {
        if (noAction != null)
            noAction();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 供外部调用的API
    /// </summary>
    /// <param name="title">标题</param>
    /// <param name="content">内容</param>
    /// <param name="cb">确定回调</param>
    /// <param name="cn">取消回调</param>
    public void ShowContent(string title, string content, ClickYesButton cb, ClickNoButton cn)
    {
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);

        this.title.text = title;
        this.content.text = content;
        yesAction = cb;
        noAction = cn;
    }

}
