using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject gameOverText = null;
    [SerializeField] GameObject gameClearText = null;
    public void GameOver()
    {
        gameOverText.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameClear()
    {
        gameClearText.SetActive(true);
        Time.timeScale = 0;
    }
    public void GameStart()
    {
        gameOverText.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            GameClear();
        }
    }
}
