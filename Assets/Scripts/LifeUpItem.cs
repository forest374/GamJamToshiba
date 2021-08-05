using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeUpItem : Item
{
    private PlayerDamage playerDamage;
    [SerializeField] int point = 100;
    private void Start()
    {
        playerDamage = GameObject.Find("Player").GetComponent<PlayerDamage>();
    }

    protected override void Use()
    {
        playerDamage.LifeUp();
    }
}
