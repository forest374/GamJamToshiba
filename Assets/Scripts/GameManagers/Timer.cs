using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Score score;
    [SerializeField] int maxTimer = 100;
    [SerializeField] Text timerText;
    [SerializeField] Goal goal;

    bool gameMove = true;

    float timer = 0;
    int time = 0;
    public float NowTimer { get => timer; set { timer = value; } }
    void Start()
    {
        time = maxTimer;
        timerText.text = time.ToString();
    }

    private void FixedUpdate()
    {
        if (gameMove)
        {
            if (time - (int)timer > 0)
            {
                timer += Time.deltaTime;
                timerText.text = (time - (int)timer).ToString();
                score.ShowScore(timer);
            }
            else
            {
                //ゲームを止める
                goal.GameOver();
            }
        }

    }

    public void GameStopCall()
    {
        gameMove = false;
    }
    public void GameStartCall()
    {
        gameMove = true;
    }
}
