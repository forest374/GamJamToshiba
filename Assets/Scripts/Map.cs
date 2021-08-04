using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    MapCreate mapCreate;
    float moveSpeed = 0.1f;

    public MapCreate MapCreate { get => mapCreate; set { mapCreate = value; } }
    public float MoveSpeed { get => moveSpeed; set {moveSpeed = value; } }

    private void FixedUpdate()
    {
        transform.Translate(new Vector2(-moveSpeed, 0));
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Limit")
        {
            mapCreate.CreateScaffold();
        }
    }
}
