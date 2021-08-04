﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] int maxTimer = 100;
    [SerializeField] GameObject gameOverText = null;
    [SerializeField] Text timerText;

    float timer = 0;
    int time = 0;
    void Start()
    {
        time = maxTimer;
        timerText.text = time.ToString();
    }

    private void FixedUpdate()
    {
        if (time - (int)timer > 0)
        {
            timer += Time.deltaTime;
            timerText.text = (time - (int)timer).ToString();
        }
        else 
        {
            //ゲームを止める
            GameOver();
        }

    }

    public void GameOver()
    {
        gameOverText.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameStart()
    {
        gameOverText.SetActive(false);
        Time.timeScale = 1;
    }
}