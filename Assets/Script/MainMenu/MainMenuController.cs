using System;
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

    [SerializeField] private CanvasGroup chatWindow;
    [SerializeField] private Button chatParentButton;
    private bool isChatOut = false;

    private void Awake()
    {
        EventManager.ResetEventDictionary();
    }

    private void Start()
    {
        ReacFunctions.GetTenRace();
        ReacFunctions.GetTenLap();

        ReacFunctions.GetUserNfts();
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

    public void ChatAnimationPopIn()
    {
        if (!isChatOut)
        {
            chatWindow.gameObject.SetActive(true);
            chatParentButton.interactable = false;
            LeanTween.alphaCanvas(chatWindow, 1, 0.75f).setOnComplete(() => chatParentButton.interactable = true);
            isChatOut = true;
        }
        else
        {
            chatParentButton.interactable = false;
            LeanTween.alphaCanvas(chatWindow, 0, 0.75f).setOnComplete(()=>ExtraAnimationChat());
            isChatOut = false;
        }
    }

    private void ExtraAnimationChat()
    {
        chatWindow.gameObject.SetActive(false);
        chatParentButton.interactable = true;
    }

}
