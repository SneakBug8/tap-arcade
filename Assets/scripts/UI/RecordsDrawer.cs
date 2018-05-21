﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsDrawer : MonoBehaviour
{

    // Use this for initialization
    Text Text;

    public GameObject DisplayNameWindow;
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



        if (newrecord)
        {
            PlayerPrefs.SetFloat("RecordFloatingTime", LevelController.Global.FloatingTime);
        }

        if (GameSparksManager.Instance.UseGameSparks)
        {
            if (!PlayerPrefs.HasKey("DisplayNameSet"))
            {
                ShowDisplayNameWindow();
                LostMenu.Global.gameObject.SetActive(false);
            }
            else
            {
                ScoreManager.SendScore(LevelController.Global.FloatingTimeInt);
            }
        }
    }

    void ShowDisplayNameWindow()
    {
        DisplayNameWindow.SetActive(true);
    }
}
