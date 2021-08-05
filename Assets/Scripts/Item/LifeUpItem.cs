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

    public override void Use()
    {
        if (!playerDamage)
        {
            GameObject.Find("Player").GetComponent<PlayerDamage>();
        }
        Debug.Log("get");
        playerDamage.LifeUp();
        Destroy(this.gameObject);
    }
}
