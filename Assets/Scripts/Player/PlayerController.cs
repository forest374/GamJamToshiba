﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D m_rb;

    PlayerMove m_playerMove;
    [SerializeField] float m_moveSpeed;

    PlayerJump m_playerJump;
    [SerializeField] float m_jumpPow;

    PlayerGetItem m_playerGetItem;

    [SerializeField] private Transform m_GroundCheck;

    [SerializeField] GroundHitTest m_hitTest;

    PlayerDamage m_playerDamage;
    [SerializeField] List<Buddy> m_buddies;
    [SerializeField] Goal m_goal;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();

        m_playerMove = gameObject.AddComponent<PlayerMove>();
        m_playerMove.Init(m_rb);

        m_playerJump = gameObject.AddComponent<PlayerJump>();
        m_playerJump.Init(m_rb);

        m_playerGetItem = gameObject.AddComponent<PlayerGetItem>();

        m_playerDamage = gameObject.AddComponent<PlayerDamage>();
        m_playerDamage.Init(m_buddies, m_goal);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && m_hitTest.IsGround)
        {
            m_playerJump.Jump(m_jumpPow);
        }

        m_playerMove.Move(m_moveSpeed);
    }
}
