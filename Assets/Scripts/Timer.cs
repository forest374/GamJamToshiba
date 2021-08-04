using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] int maxTimer = 100;
    [SerializeField] GameObject timeUp = null;
    [SerializeField] Text timerText;

    float timer = 100;
    int time = 0;
    void Start()
    {
        timer = maxTimer;
        time = (int)timer;
        timerText.text = time.ToString();
    }

    private void FixedUpdate()
    {
        if (timer > 1)
        {
            timer -= Time.deltaTime;
            time = (int)timer;
            timerText.text = time.ToString();
        }
        else 
        {
            timeUp.SetActive(true);
            //ゲームを止める
        }

    }
}
