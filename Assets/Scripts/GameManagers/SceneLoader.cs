using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    string sceneNameToBeLoaded;
    /// <summary>
    /// 即時にシーンを変える
    /// </summary>
    /// <param name="sceneName"></param>
    public void LoadScene(string sceneName)
    {
        sceneNameToBeLoaded = sceneName;
        SceneManager.LoadScene(sceneNameToBeLoaded);
    }
}
