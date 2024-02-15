using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{
    [SerializeField] private CharacterSO so;

    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _characterSelected;

    public void ChangeLevel(string levelName)
    {
        SceneLoadingManager.instance.ChangeScene(levelName);
    }


    public void ChangePlayerSkin(int skin)
    {
        _characterSelected.sprite = _sprites[skin];
        so.numberMat = skin;
    }


}
