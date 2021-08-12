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
    List<GameObject> m_aliveBuddies = new List<GameObject>();
    /// <summary>
    /// 現在表示されているバディのインデックス
    /// </summary>
    int m_index;
    /// <summary>
    /// 現在表示されているバディ
    /// </summary>
    public Buddy ActiveBuddy
    {
        get
        {
            return m_aliveBuddies[m_index].GetComponent<Buddy>();
        }
    }

    Goal m_goal;

    public void Init(List<Buddy> buddys, Goal goal)
    {
        for (int i = 0; i < buddys.Count; i++)
        {
            m_buddies.Add(buddys[i].gameObject);
        }

        m_aliveBuddies = m_buddies;
        m_index = m_aliveBuddies.Count - 1;

        m_goal = goal;
    }

    public void LifeUp()
    {
        if (m_index != 2)
        {
            m_aliveBuddies[m_index].SetActive(false);
            Vector2 point = m_aliveBuddies[m_index].transform.position;

            m_index++;
            m_aliveBuddies[m_index].SetActive(true);
            m_aliveBuddies[m_index].transform.position = point;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (m_index != 0)
            {
                m_aliveBuddies[m_index].SetActive(false);
                Vector2 point = m_aliveBuddies[m_index].transform.position;

                m_index--;
                m_aliveBuddies[m_index].SetActive(true);
                m_aliveBuddies[m_index].transform.position = point;
            }
            else
            {
                m_aliveBuddies[m_index].SetActive(false);
                m_goal.GameOver();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Enemy"))
        //{
        //    if (m_index != 0)
        //    {
        //        m_aliveBuddy[m_index].SetActive(false);
        //        Vector2 point = m_aliveBuddy[m_index].transform.position;

        //        m_index--;
        //        m_aliveBuddy[m_index].SetActive(true);
        //        m_aliveBuddy[m_index].transform.position = point;
        //    }
        //    else
        //    {
        //        m_aliveBuddy[m_index].SetActive(false);
        //        m_goal.GameOver();
        //    }
        //}
    }
}
