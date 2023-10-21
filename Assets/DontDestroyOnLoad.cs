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


    IEnumerator LoadSceneWithDelay(string sceneName, string loadingName)
    {
        // Espera el tiempo especificado antes de cargar la escena
        yield return new WaitForSeconds(delayBeforeSceneChange);

        Debug.Log("Cargando escena");
        // Inicia la carga asincrónica de la escena
        StartCoroutine(LoadAsync(sceneName, loadingName));
    }



    public void LoadScene(string sceneName, string loadingName )
    {
        Debug.Log("Cargando escena");
        // start asynchronous scene loading
        StartCoroutine(LoadSceneWithDelay(sceneName,loadingName));
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

