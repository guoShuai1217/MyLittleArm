﻿/*
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

namespace NotificationJunior
{
    public class CharacterManager : ManagerBase
    {

        public static CharacterManager Instance;

        private void Awake()
        {
            Instance = this;
        }


    }
}