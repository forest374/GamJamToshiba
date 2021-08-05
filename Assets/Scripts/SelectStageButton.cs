using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStageButton : MonoBehaviour
{
    [SerializeField] SceneLoader m_sceneLoader;
    [SerializeField] Transform m_mapSet;
    List<GameObject> m_maplist;

    private void Start()
    {
        // イベントにイベントハンドラーを追加
        SceneManager.sceneLoaded += SceneLoaded;
    }

    public void Onclick(string sceneName)
    {
        m_sceneLoader.LoadScene(sceneName);
        Transform[] maps = m_mapSet.GetComponentsInChildren<Transform>();

        m_maplist = new List<GameObject>();
        foreach (Transform obj in maps)
        {
            m_maplist.Add(obj.gameObject);
            obj.gameObject.SetActive(true);
        }
    }

    void SceneLoaded(Scene nextScene, LoadSceneMode mode)
    {
        FindObjectOfType<MapCreate>().Maps = m_maplist;
    }
}
