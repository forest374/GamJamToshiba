using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.03f;

    Vector2 trans;
    void Start()
    {
        trans = new Vector2(-moveSpeed, 0);
    }

    void FixedUpdate()
    {
        transform.Translate(trans);
    }
}
