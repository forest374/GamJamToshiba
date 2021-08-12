using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator anim = null;
    public Buddy m_buddy = null;
    bool m_isAttack = false;

    public void Init()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        m_isAttack = true;
        ChangeAnim();
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
            //敵倒したらお供喋らす
            if (m_isAttack)
            {
                m_buddy.Talk();
            }
        }
    }
}
