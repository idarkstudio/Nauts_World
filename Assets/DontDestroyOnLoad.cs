using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DontDestroyOnLoad : MonoBehaviour
{
    public GameObject dontDestroy;

    public void Awake()
    {
        DontDestroyOnLoad(dontDestroy);
        DontDestroyOnLoad(this);
    }

    public void NextLevel()
    {
        this.LoadScene("MainMenu","Loading1");
    }
    public void LoadScene(string sceneName, string loadingName )
    {
        // start asynchronous scene loading
        StartCoroutine(LoadAsync(sceneName,loadingName));
    }
    IEnumerator LoadAsync(string sceneName, string loadingName)
    {
        SceneManager.LoadScene(loadingName);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            if (progress > 0.9f)
                operation.allowSceneActivation = true;
            
            yield return null;
        }
    }

}

