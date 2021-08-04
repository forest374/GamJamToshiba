using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_jumpPow;
    Rigidbody2D m_rb;

    PlayerJump m_playerMove;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();

        m_playerMove = gameObject.AddComponent<PlayerJump>();
        m_playerMove.Init(m_rb);
    }

    private void Update()
    {
        m_playerMove.Jump(m_jumpPow);
    }
}
