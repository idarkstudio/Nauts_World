using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{
  


    public void ChangeLevel(string levelName)
    {

        SceneManager.LoadScene(levelName);


    }





}
