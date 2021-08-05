using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    bool gameMove = true;

    MapCreate mapCreate;
    float moveSpeed = 0.1f;

    public MapCreate MapCreate { get => mapCreate; set { mapCreate = value; } }
    public float MoveSpeed { get => moveSpeed; set {moveSpeed = value; } }

    private void FixedUpdate()
    {
        if (gameMove)
        {
            transform.Translate(new Vector2(-moveSpeed, 0));

            float x = transform.position.x;
            if (x <= -20)
            {
                mapCreate.CreateScaffold();
            }
        }
    }

    public void MapStopCall()
    {
        gameMove = false;
    }
    public void MapStartCall()
    {
        gameMove = true;
    }

}
