/*
 *		Description : 玩家 , 点击右键捡箱子
 *		
 *		              箱子的层级一定是 box , 不然检测不到
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08.29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Ray ray;
    private RaycastHit hit;

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             // 距离无限远 , 检测层级是 box 的物体
            if(Physics.Raycast(ray,out hit , Mathf.Infinity, 1 << LayerMask.NameToLayer("box")))
            {
                Debug.Log("检测到" + hit.collider.name);
                hit.collider.GetComponent<Box>().DestroySelf();
            }
        }
    }



}
