using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    float timer = 0;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float create = Random.Range(0.5f, 1.5f);
        if (timer > create)
        {
            Vector2 mapsHeight = new Vector2(16, 0);

            Instantiate(enemy, mapsHeight, Quaternion.identity);
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
