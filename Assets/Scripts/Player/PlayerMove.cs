using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D m_rb;
    float m_inputAxis;

    public void Init(Rigidbody2D rb)
    {
        m_rb = rb;
    }

    public void Move(float speed)
    {
        m_inputAxis = Input.GetAxis("Horizontal");
        m_rb.velocity = new Vector2(m_inputAxis * speed, m_rb.velocity.y);
    }
}
