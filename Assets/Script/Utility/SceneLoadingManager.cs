using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadingManager : MonoBehaviour
{
    public static SceneLoadingManager instance;
    [SerializeField] private string _loadingSceneName;
    [SerializeField] private string _actualScene = "Connect";
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(ChangeSceneCoroutine(sceneName));
    }

    private IEnumerator ChangeSceneCoroutine(string sceneName)
    {
        
        var loadingAsyncScreen = SceneManager.LoadSceneAsync(_loadingSceneName);
        yield return new WaitUntil(()=>loadingAsyncScreen.isDone);
        



        // Debug.Log(2);
        // var unloadSceneAsync = SceneManager.UnloadSceneAsync(_actualScene);
        // yield return new WaitUntil(()=>unloadSceneAsync.isDone);
        //
        var newSceneLoadAsync = SceneManager.LoadSceneAsync(sceneName);
        _actualScene = sceneName;
        yield return new WaitUntil(()=>newSceneLoadAsync.isDone);
        
        // Debug.Log(4);
        // var unloadingLoading = SceneManager.UnloadSceneAsync(_loadingSceneName);
        // yield return new WaitUntil(()=>unloadingLoading.isDone);
    }
}
