using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseMenu;
    //public CameraController _cameraContoller;
    public delegate void PauseEventHandler(bool isPaused);
    public static event PauseEventHandler OnPauseChanged;
    string mainmenu = "mainmenu" ;

    void Start()
    {
        Time.timeScale = 1;
        if (OnPauseChanged != null)
            OnPauseChanged(false);

    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_pauseMenu.activeSelf)
            {
                PausedGame();
            }
            else
            {
                ResumeGame();
            }

        }

    }


    private void PausedGame()
    {
        Debug.Log("Pausa");
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        _pauseMenu.SetActive(true);
        if (OnPauseChanged != null)
            OnPauseChanged(true);


        
    }

    public void ResumeGame()
    {
        Debug.Log("Resume");
        Time .timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        _pauseMenu.SetActive(false);
        if (OnPauseChanged != null)
            OnPauseChanged(false);
    }


    public void ExitGame()//string scene)
    {
        if (OnPauseChanged != null)
            OnPauseChanged(false);
        //SceneManager.LoadScene(scene);
        ReacFunctions.ReturnToMainMenu(mainmenu);

    }



}
