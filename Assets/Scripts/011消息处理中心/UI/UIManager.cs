﻿/*
 *		Description : UI 模块管理器
 *
 *		CreatedBy : guoShuai
 *
 *		DataTime : 2018.09.06
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NotificationJunior
{
    public class UIManager : ManagerBase
    {

        public static UIManager Instance;

        private void Awake()
        {
            Instance = this;
        }



    }
}