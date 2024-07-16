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

    [SerializeField] private List<CanvasGroup> menus = new List<CanvasGroup>();

    private void Start()
    {
        ReacFunctions.GetTenRace();
        ReacFunctions.GetTenLap();
    }

    public void ChangeLevel(string levelName)
    {
        SceneLoadingManager.instance.ChangeScene(levelName);
    }


    public void ChangePlayerSkin(int skin)
    {
        _characterSelected.sprite = _sprites[skin];
        so.numberMat = skin;
    }

    public void ChangeMenu(CanvasGroup menuToOpen)
    {
        for (int i = 0; i < menus.Count; i++)
        {
            menus[i].alpha = 0;
            menus[i].interactable = false;
            menus[i].blocksRaycasts = false;
        }

        menuToOpen.alpha = 1;
        menuToOpen.interactable = true;
        menuToOpen.blocksRaycasts = true;
    }


}
