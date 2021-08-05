using System.Collections;
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

    PlayerAttack m_playerAttack;

    //[SerializeField] private Transform m_GroundCheck;

    [SerializeField] GroundHitTest m_hitTest;

<<<<<<< HEAD
    PlayerDamage m_playerDamage;
    [SerializeField] List<Buddy> m_buddies;
    [SerializeField] Goal m_goal;

=======

    [SerializeField] Goal m_goal;

    bool m_move = true;

>>>>>>> 114b2ec258951d76426c87a772f87b000bc22259
    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();

        m_playerMove = gameObject.AddComponent<PlayerMove>();
        m_playerMove.Init(m_rb);

        m_playerJump = gameObject.AddComponent<PlayerJump>();
        m_playerJump.Init(m_rb);

        m_playerGetItem = gameObject.AddComponent<PlayerGetItem>();
<<<<<<< HEAD

        m_playerDamage = gameObject.AddComponent<PlayerDamage>();
        m_playerDamage.Init(m_buddies, m_goal);
=======
        m_playerGetItem.Goal = m_goal;

        m_playerAttack = gameObject.AddComponent<PlayerAttack>();
>>>>>>> 114b2ec258951d76426c87a772f87b000bc22259
    }

    private void Update()
    {
        if (m_move)
        {
            if (Input.GetButtonDown("Jump") && m_hitTest.IsGround)
            {
                m_playerJump.Jump(m_jumpPow);
            }

            if (Input.GetButtonDown("Fire1"))
            {
                m_playerAttack.Attack();
            }

            m_playerMove.Move(m_moveSpeed);
        }

    }

    public void GameStopCall()
    {
        m_move = false;
    }
    public void GameStartCall()
    {
        m_move = true;
    }
}
