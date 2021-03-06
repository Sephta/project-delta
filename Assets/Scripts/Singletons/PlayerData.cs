﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("Player Global Data")]
    public int _playerEXP = 0;

    [Header("Instance Data")]
    public static PlayerData _instance;
    [SerializeField, ReadOnly] private bool gameStart = false;

    void Awake()
    {
        if (!gameStart)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
            gameStart = true;
        }
    }
}
