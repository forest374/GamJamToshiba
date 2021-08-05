using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetItem : MonoBehaviour
{
    Goal goal;
    public Goal Goal { get => goal; set {goal = value; } }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Item") )
        {
            Debug.Log("アイテムを取得した！");
        }

        if (collision.CompareTag("Goal"))
        {
            goal.GameClear();
        }
    }
}
