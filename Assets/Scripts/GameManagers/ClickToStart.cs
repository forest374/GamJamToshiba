using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToStart : MonoBehaviour
{
    [SerializeField] GameObject clickToStart;
    [SerializeField] PlayerController player;
    void Start()
    {
        clickToStart.SetActive(true);
        Time.timeScale = 0;
    }


    public void Click()
    {
        player.Move = true;
        clickToStart.SetActive(false);
        Time.timeScale = 1;
    }
}
