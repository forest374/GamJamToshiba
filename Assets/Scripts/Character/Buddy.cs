using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum buddyType
{
    いぬ,
    さる,
    きじ
}
public class Buddy : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Vector2 point = new Vector2(-1f, 0.5f);

    /// <summary>
    /// 声
    /// </summary>
    [SerializeField] AudioClip m_voice = null;
    AudioSource m_audioSource;
    PlayerController m_playerController = null;

    private void Start()
    {
        m_playerController = FindObjectOfType<PlayerController>();
        m_audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector2 trans = point + (Vector2)player.transform.position;

        trans -= (Vector2)this.transform.position;

        if (trans.x > 0 || trans.x < -0.3f || trans.y > 0.2f || trans.y < -0.2f)
        {
            transform.Translate(trans / 10);
        }
    }

    /// <summary>
    /// 話す
    /// </summary>
    public void Talk()
    {


        if (m_voice)
        {
            m_audioSource.PlayOneShot(m_voice);
        }
        else
        {
            Debug.Log(gameObject.name + "の音声が設定されていません。");
        }
    }
}
