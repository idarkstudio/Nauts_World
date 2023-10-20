using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DontDestroyOnLoad : MonoBehaviour
{
    public GameObject loginManager;
    private static DontDestroyOnLoad Instance;
    public void Awake()
    {
        Debug.Log("Awake dont destroy");
        DontDestroyOnLoad(loginManager);
        DontDestroyOnLoad(this);
        Instance = this;
        Debug.Log("Awake dont destroy2");
    }

    public void NextLevel()
    {
        this.LoadScene("MainMenu","Loading1");
    }
    public void LoadScene(string sceneName, string loadingName )
    {
        Debug.Log("Cargando escena");
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

