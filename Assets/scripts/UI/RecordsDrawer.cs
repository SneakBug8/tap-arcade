﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsDrawer : MonoBehaviour
{

    // Use this for initialization
    Text Text;
    private void Awake()
    {
        Text = GetComponent<Text>();
    }
    public void Redraw()
    {
        var record = PlayerPrefs.GetFloat("RecordFloatingTime");
        var newrecord = LevelController.Global.FloatingTime > record;
        var recordtext = (newrecord) ? " New record!" : "";
        Text.text = string.Format(
            "Your score - {0}.{1}",
            LevelController.Global.FloatingTimeInt,
            recordtext
            );

        ScoreManager.SendScore(LevelController.Global.FloatingTimeInt);        

        if (newrecord)
        {
            PlayerPrefs.SetFloat("RecordFloatingTime", LevelController.Global.FloatingTime);
        }
    }
}
