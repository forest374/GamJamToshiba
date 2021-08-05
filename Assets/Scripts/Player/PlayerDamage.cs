using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    /// <summary>
    /// バディ
    /// </summary>
    List<GameObject> m_buddies = new List<GameObject>();
    /// <summary>
    /// 生きているバディ
    /// </summary>
    List<GameObject> m_aliveBuddy = new List<GameObject>();
    /// <summary>
    /// 次に居なくなるバディのインデックス
    /// </summary>
    int m_index;

    Goal m_goal;

    public void Init(List<Buddy> buddys, Goal goal)
    {
        for (int i = 0; i < buddys.Count; i++)
        {
            m_buddies.Add(buddys[i].gameObject);
        }

        m_aliveBuddy = m_buddies;
        m_index = m_aliveBuddy.Count - 1;

        m_goal = goal;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (m_aliveBuddy.Count != 0)
            {
                m_aliveBuddy[m_index].SetActive(false);
                m_aliveBuddy.Remove(m_aliveBuddy[m_index]);
                m_index--;
            }
            else
            {
                m_goal.GameOver();
            }
        }
    }
}
