/*
 *		Description : 子弹类是可以回收的 
 *		
 *		               一定要继承 ResuableBase
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.08.29
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : ResuableBase
{

    bool isShoot = false;

    private void Awake()
    {
        transform.parent = GameObject.Find("bulletParent").transform;
    }

    public override void Spawn()
    {
        print("I am Come ");
        isShoot = true;
        Invoke("DelayDestroy", 3f);
    }

    public override void UnSpawn()
    {
        isShoot = false;
        transform.localPosition = Vector3.zero;
        print(" I am Back ");
    }

    private void Update()
    {
        if (isShoot)
        {
            transform.position += Time.deltaTime * 30f * transform.forward;
        }
    }

    private void DelayDestroy()
    {
        PoolController.Instance.UnSpawn(gameObject);
    }

    
}
