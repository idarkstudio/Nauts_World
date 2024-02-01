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


    public void ChangePlayerSkin()
    {
        if (so.numberMat == 0)
            so.numberMat = 1;
        else if (so.numberMat == 1)
            so.numberMat = 0;
    }


}
