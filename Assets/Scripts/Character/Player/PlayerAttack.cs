using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim = null;
    public Buddy m_buddy = null;
    bool m_isAttack = false;
    bool m_isHitEnemy = false;
    GameObject m_enemyObj = null;

    public void Init()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        if (m_isHitEnemy)
        {
            m_isAttack = true;
            m_buddy.Talk();
            Destroy(m_enemyObj);
            ChangeAnim();
        }
    }

    public void AttackEnd()
    {
        m_isAttack = false;
        ChangeAnim();
    }

    /// <summary>
    /// アニメーションを変える
    /// </summary>
    void ChangeAnim()
    {
        anim.SetBool("Attack", m_isAttack);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            m_isHitEnemy = true;
            m_enemyObj = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            m_isHitEnemy = false;
            m_enemyObj = null;
        }
    }
}
