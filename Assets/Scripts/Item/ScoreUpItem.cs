﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpItem : Item
{
    private Score score;
    [SerializeField] int point = 100;
    private void Start()
    {
        score = GameObject.Find("GameManager").GetComponent<Score>();
    }
    public override void Use()
    {
        if (!score)
        {
            GameObject.Find("GameManager").GetComponent<Score>();
        }
        score.ItemUp(point);
        Destroy(this.gameObject);
    }
}
