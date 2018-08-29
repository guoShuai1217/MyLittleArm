/*
 *		Description : 
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    Ray ray;
    RaycastHit hit; // 检测单个物体
    RaycastHit[] hitArr; // 检测多个物体
    Collider[] colliderArr; // 检测某一半径内的物体 


    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
           
            //射线检测单个物体
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << LayerMask.NameToLayer("11")))
            {
                // print("你点击了" + hit.transform.name);
                print("你点击了" + hit.collider.name);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            // 射线检测多个物体
            hitArr = Physics.RaycastAll(ray, Mathf.Infinity, 1 << LayerMask.NameToLayer("11"));
            if (hitArr.Length > 0)
            {
                for (int i = 0; i < hitArr.Length; i++)
                {
                    print(hitArr[i].collider.name);
                }
            }
        }
         // 射线检测半径内的物体
        if (Input.GetMouseButtonDown(2))
        {
            colliderArr = Physics.OverlapSphere(transform.position, 3, 1 << LayerMask.NameToLayer("11"));
            if (colliderArr.Length > 0)
            {
                for (int i = 0; i < colliderArr.Length; i++)
                {
                    print(colliderArr[i].name);
                }

            }

        }


    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, 3);
    //}

}
