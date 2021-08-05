using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.01f;
    private void FixedUpdate()
    {
        if (this.transform.position.x > -80)
        {
            transform.Translate(new Vector2(-moveSpeed, 0));
        }
        else
        {
            Destroy(this);
        }
    }
}
