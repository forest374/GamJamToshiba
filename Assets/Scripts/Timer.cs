using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] int maxTimer = 100;
    [SerializeField] GameObject timeUp = null;


    float timer;
    void Start()
    {
        timer = maxTimer;
    }

    private void FixedUpdate()
    {
        if (timer >= 0)
        {
            timeUp.SetActive(true);
            //ゲームを止める
        }
        else
        {
            timer -= Time.deltaTime;
        }

    }
}
