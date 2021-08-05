using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D m_rb;
    public void Init(Rigidbody2D rb)
    {
        m_rb = rb;
    }

    public void Jump(float jumpPow)
    {
        m_rb.velocity = new Vector2(m_rb.velocity.x, jumpPow);
    }
}
