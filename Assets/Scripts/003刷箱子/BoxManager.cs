/*
 *		Description :    生成箱子 , 箱子的数量增加
 *		
 *		                 箱子数量减少
 *			             
 *			             显示拾取的箱子数量 , 保存数据(下次打开可以获取上次拾取的数量)
 *			             
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08.29
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour
{
    [SerializeField]
    private Transform boxParent;    // 箱子的父物体 

    [SerializeField]
    private Transform floor;  // 地面(是个cube,floor.TransformPoint()这个API自己缩放了,比例是不会变的,用于随机箱子的位置)

    private Box box;  // 箱子

    private int maxCount = 10; // 箱子的最大数量

    private int currentCount = 0; // 箱子的当前数量

    private float timer = 0; // 计时器

    private string saveCount = "saveCount"; // PlayerPrefs 的 key 值 

    private int saveBoxCount = 0; // 记录拾取的箱子数量 

    [SerializeField]
    private Text countText; // 用于显示箱子数量

    private void Start()
    {
        saveBoxCount = PlayerPrefs.GetInt(saveCount); // PlayerPrefs 读取数据
        countText.text = "拾取数量:" + saveBoxCount;
        print("上次拾取了" + saveBoxCount + "个箱子");

        box = Resources.Load<Box>("Prefabs/Box");
    }

    private void Update()
    {
        if (currentCount >= maxCount)
            return;

        if (Time.time - timer > 0)
        {
            timer = Time.time + 1.5f;
            Box _box = Instantiate(box);
            _box.transform.SetParent(boxParent);
            // 随机箱子位置
            _box.transform.localPosition = floor.TransformPoint(UnityEngine.Random.Range(-0.5f, 0.5f), 0, UnityEngine.Random.Range(-0.5f, 0.5f));
            // 注册数量减少的事件
            _box.countReduce = CountReduce;
            currentCount++;
        }

    }

    private void CountReduce()
    {
        currentCount--;
        saveBoxCount++;
        countText.text = "拾取数量:" + saveBoxCount;
        PlayerPrefs.SetInt(saveCount, saveBoxCount); // PlayerPrefs 保存数据
    }
}
