using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardSetter : MonoBehaviour
{
    [SerializeField] private LeaderboardProfiler[] profiles = new LeaderboardProfiler[10];

    [SerializeField] private TMP_Text tenLapsText;
    [SerializeField] private TMP_Text tenRacesText;
    private string colorSelectedHex = "41ABDD";
    Color newLightBlue;
    private string colorNormalHex = "FFFFFF";
    Color newWhite;

    [SerializeField] private GameObject loadingScreen;


    private void Awake()
    {
        EventManager.Subscribe("TenRaceCallBack", GetTenRace);
        EventManager.Subscribe("TenLapCallBack", GetTenLaps);
    }

    private void Start()
    {
        ColorUtility.TryParseHtmlString(colorSelectedHex, out newLightBlue);
        ColorUtility.TryParseHtmlString(colorNormalHex, out newWhite);
    }

    public void GetTenLaps(params object[] parameters)
    {
        var data = (Score[])parameters[0];

        for (int i = 0; i < data.Length; i++)
        {
            profiles[i].SetterProfileFromLap(data[i]);
        }

        loadingScreen.SetActive(false);
    }

    public void GetTenRace(params object[] parameters)
    {
        var data = (Score[])parameters[0];

        for (int i = 0; i < data.Length; i++)
        {
            profiles[i].SetterProfileFromRace(data[i]);
        }

        loadingScreen.SetActive(false);
    }

    public void ChangeToTenLaps()
    {

        tenLapsText.color = newLightBlue;
        tenRacesText.color = newWhite;
        tenLapsText.GetComponent<Button>().interactable = false;
        tenRacesText.GetComponent<Button>().interactable = true;

        loadingScreen.SetActive(true);

        ReacFunctions.GetTenLap();
    }

    public void ChangeToTenRace()
    {
        tenRacesText.color = newLightBlue;
        tenLapsText.color = newWhite;
        tenRacesText.GetComponent<Button>().interactable = false;
        tenLapsText.GetComponent<Button>().interactable = true;

        loadingScreen.SetActive(true);

        ReacFunctions.GetTenRace();
    }
}
