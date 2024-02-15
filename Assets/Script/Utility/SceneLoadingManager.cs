using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadingManager : MonoBehaviour
{
    public static SceneLoadingManager instance;
    [SerializeField] private string _loadingSceneName;
    [SerializeField] private string _actualScene;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        instance = this;
    }

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(ChangeSceneCoroutine(sceneName));
    }

    private IEnumerator ChangeSceneCoroutine(string sceneName)
    {
        var loadingAsyncScreen = SceneManager.LoadSceneAsync(_loadingSceneName);
        yield return new WaitUntil(()=>loadingAsyncScreen.isDone);

        var unloadSceneAsync = SceneManager.UnloadSceneAsync(_actualScene);
        yield return new WaitUntil(()=>unloadSceneAsync.isDone);
        
        var newSceneLoadAsync = SceneManager.LoadSceneAsync(sceneName);
        _actualScene = sceneName;
        yield return new WaitUntil(()=>newSceneLoadAsync.isDone);
        
        var unloadingLoading = SceneManager.UnloadSceneAsync(_loadingSceneName);
        yield return new WaitUntil(()=>unloadingLoading.isDone);
    }
}
