using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Score score;
    [SerializeField] AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (audioClip)
            {
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
            }

            if (!score)
            {
                score = GameObject.Find("GameManager").GetComponent<Score>();
            }

            score.EnemyDeath();
        }
    }
}
