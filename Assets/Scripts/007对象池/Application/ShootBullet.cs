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

public class ShootBullet : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            PoolController.Instance.Spawn("Bullet");
        }
    }



}
