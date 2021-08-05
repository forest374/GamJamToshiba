using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] MapCreate mapCreate;
    [SerializeField] Timer timer;
    [SerializeField] PlayerController player;

    [SerializeField] GameObject gameOverText = null;
    [SerializeField] GameObject gameClearText = null;
    public void GameOver()
    {
        gameOverText.SetActive(true);
        GameStop();
    }
    public void GameClear()
    {
        gameClearText.SetActive(true);
        GameStop();
    }
    public void GameMove()
    {
        gameOverText.SetActive(false);
        GameStart();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            GameClear();
        }
    }
    public void GoalPoint()
    {
        timer.GameStopCall();
        mapCreate.GameStopCall();
    }

    void GameStop()
    {
        timer.GameStopCall();
        mapCreate.GameStopCall();
        player.GameStopCall();
    }
    void GameStart()
    {
        timer.GameStopCall();
        mapCreate.GameStopCall();
        player.GameStopCall();
    }
}
