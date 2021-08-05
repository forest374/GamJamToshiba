using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] Text scoreText;
    int enemyDeath = 0;
    int itemScore = 0;


    public void ShowScore(float nowTimer)
    {
        float point = nowTimer * 50;
        int scorePoint = (int)point;
        scorePoint += enemyDeath * 100 + itemScore;

        scoreText.text = scorePoint.ToString();
    }

    public void EnemyDeath()
    {
        enemyDeath++;
    }

    public void ItemUp(int num)
    {
        itemScore += num;
    }
}
