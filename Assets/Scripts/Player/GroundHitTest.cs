using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHitTest : MonoBehaviour
{
    bool m_isGround = true;
    public bool IsGround { private set { } get { return m_isGround; } }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            m_isGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            m_isGround = false;
        }
    }
}
