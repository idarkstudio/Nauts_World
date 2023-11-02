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
    public float delayBeforeSceneChange = 4.0f;
    public void Awake()
    {
        DontDestroyOnLoad(loginManager);
        DontDestroyOnLoad(this);
        Instance = this;
    }


    public void CargarEscena(string sceneName, string loadingName )
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

        yield return new WaitForSeconds(4f);

        operation.allowSceneActivation = true;
            
        yield return null;
        
    }

}

