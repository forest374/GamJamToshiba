using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D m_rb;
    bool m_isGrounded = true;
    public void Init(Rigidbody2D rb)
    {
        m_rb = rb;
    }

    public void Jump(float jumpPow)
    {
        if (Input.GetButtonDown("Jump") &&
            m_isGrounded)
        {
            m_rb.velocity = new Vector2(m_rb.velocity.x, jumpPow);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_isGrounded = true;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_isGrounded = false;
        }
    }
}
