using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buddy : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector2 point = new Vector2(-1f, 0.5f);

    void Update()
    {
        Vector2 trans = point + (Vector2)player.transform.position;


        trans -= (Vector2)this.transform.position;

        if (trans.x > 0 || trans.x < -0.3f || trans .y > 0.2f || trans.y < -0.2f)
        {
            transform.Translate(trans / 10);
        }
    }
}
