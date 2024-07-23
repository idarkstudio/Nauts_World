using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;


public class MainMenuController : MonoBehaviour
{
    [SerializeField] private CharacterSO so;

    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _characterSelected;

    [SerializeField] private List<CanvasGroup> menus = new List<CanvasGroup>();

    [SerializeField] private CanvasGroup chatWindow;
    [SerializeField] private Button chatParentButton;
    private bool isChatOut = false;

    [Header("Intro Cinematic")]
    [SerializeField] private List<Animator> doors = new List<Animator>();
    [SerializeField] private Transform cameraTrans;
    [SerializeField] private Transform cameraFinalPos;
    [SerializeField] private float timerCinematic;

    [SerializeField] private CinemachineVirtualCamera currentCamera;
    [SerializeField] private List<CinemachineVirtualCamera> listOfCameras = new List<CinemachineVirtualCamera>();
    [SerializeField] private CinemachineVirtualCamera raceCamera;
    [SerializeField] private CinemachineVirtualCamera collectionCamera;

    private void Awake()
    {
        EventManager.ResetEventDictionary();
    }

    private void Start()
    {
        ReacFunctions.GetTenRace();
        ReacFunctions.GetTenLap();

        ReacFunctions.GetUserNfts();

        StartCinematicIntro();
    }

    private void StartCinematicIntro()
    {
        LeanTween.move(cameraTrans.gameObject, cameraFinalPos, timerCinematic)
            .setEaseInOutCubic()
            .setDelay(1.5f);
        StartCoroutine(WaitingDoors(0, doors[0]));
        StartCoroutine(WaitingDoors(0.05f, doors[1]));
        StartCoroutine(WaitingDoors(0.1f, doors[2]));
        StartCoroutine(WaitingDoors(0.15f, doors[3]));
        StartCoroutine(WaitingDoors(0.2f, doors[4]));

    }

    private IEnumerator WaitingDoors(float seconds, Animator animToEnable)
    {
        yield return new WaitForSeconds(seconds);
        animToEnable.enabled = true;
    }

    public void ChangeCamera(CinemachineVirtualCamera cameraToEnable)
    {
        for (int i = 0; i < listOfCameras.Count; i++)
        {
            listOfCameras[i].gameObject.SetActive(false);
        }

        cameraToEnable.gameObject.SetActive(true);
        currentCamera = cameraToEnable;
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

        LeanTween.alphaCanvas(menuToOpen, 1, 2);
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
