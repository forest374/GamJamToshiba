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
    int m_index = 0;
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
    Goal m_goal = null;
    float m_waiteRate = 1;
    int m_rateCount = 0;

    public void Init(List<Buddy> buddys, Goal goal)
    {
        for (int i = 0; i < buddys.Count; i++)
        {
            m_buddies.Add(buddys[i].gameObject);
        }

        m_aliveBuddies = new List<GameObject>(m_buddies);
        m_index = 0;

        m_goal = goal;
    }

    /// <summary>
    /// 回復する
    /// </summary>
    public void LifeUp()
    {
        if (m_aliveBuddies.Count != m_buddies.Count)
        {
            //バディのポジションを後ろにずらす
            MovePosition(-1);
            int aliveIndex = m_buddies.Count - m_aliveBuddies.Count - 1;
            //登録されているバディから指定したインデックスのバディを生き返らせる
            m_aliveBuddies.Insert(0, m_buddies[aliveIndex]);
            //先頭のバディをアクティブ状態にする
            m_aliveBuddies[0].SetActive(true);
        }
    }

    /// <summary>
    /// ポジションを移動する
    /// </summary>
    /// <param name="addPosx">加算されるポジション</param>
    void MovePosition(float addPosx)
    {
        for (int i = 0; i < m_aliveBuddies.Count; i++)
        {
            Vector2 point = m_aliveBuddies[i].GetComponent<Buddy>().Pos;
            point = new Vector2(point.x + addPosx, point.y);
            m_aliveBuddies[i].GetComponent<Buddy>().Pos = point;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //敵に当たったら
        if (collision.gameObject.CompareTag("Enemy") &&
            m_rateCount == 0)
        {
            m_rateCount = 1;

            Destroy(collision.gameObject);
            //先頭のバディを非アクティブにする
            m_aliveBuddies[0].SetActive(false);
            //生きているバディから先頭のバディを外す
            m_aliveBuddies.RemoveAt(0);
            //生きているバディが居なかったら
            if (m_aliveBuddies.Count == 0)
            {
                m_goal.GameOver();
                return;
            }

            //バディのポジションを前にずらす
            MovePosition(1);

            StartCoroutine("RateControler");
        }
    }

    IEnumerator RateControler()
    {
        yield return m_waiteRate;
        m_rateCount = 0;
        yield return null;
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
