using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{
    [SerializeField] private CharacterSO so;


    public void ChangeLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);

    }


    public void ChangePlayerSkin(int skin)
    {
        so.numberMat = skin;
    }


}
