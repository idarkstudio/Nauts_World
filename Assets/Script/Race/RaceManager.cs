using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour
{
    [SerializeField] private Transform startingLine;
    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private List<CinemachineVirtualCamera> allVcams;

    private bool raceCurrentlyInProgress;

    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private float countdownTime = 5f;

    [SerializeField] private GameObject parentTotalTimeText;
    [SerializeField] private TextMeshProUGUI totalTimeText;
    [SerializeField] private GameObject parentLapTimeText;
    [SerializeField] private TextMeshProUGUI lapTimeText;
    [SerializeField] private float lapTimeTotal = 0f;
    [SerializeField] private float lapTimeMinutesTotal = 0f;
    [SerializeField] private float lapTime = 0f;
    [SerializeField] private List<TimeSpan> lapTimersRecord = new List<TimeSpan>();
    private TimeSpan lapTimeTotalTimer;

    [SerializeField] private TextMeshProUGUI lapNumberText;
    [SerializeField] private int numberOfLaps = 3;
    [SerializeField] private int currentLap = 1;
    [SerializeField] private int checkpointsPassed = 0;

    [SerializeField] private int numberOfCheckpoints = 4;
    public int numberOfPlayers = 1;

    private List<GameObject> _playersInGame = new List<GameObject>();

    [SerializeField] private GameObject _finishLine;


    [Header("Ending Timers")] [SerializeField]
    private GameObject endPanel;

    [SerializeField] private List<TextMeshProUGUI> timersEndText = new List<TextMeshProUGUI>();
    [SerializeField] private TextMeshProUGUI timerTotalEndText;
    [SerializeField] private List<GameObject> bestTimerText = new List<GameObject>();

    [Header("Bg Black")]
    [SerializeField] private InitialBackground ibg;

    private void Awake()
    {
    }


    void Start()
    {
        SetterRaceInProgess(false);
        SpawnPlayers();
        lapNumberText.text = currentLap + "/" + numberOfLaps;
    }

    void Update()
    {
        if (IsRaceInProgress())
        {

            lapTimeTotal += Time.deltaTime;
            totalTimeText.text = lapTimeMinutesTotal.ToString() + ":" + lapTimeTotal.ToString("00.00");

            lapTime = lapTimeTotal;

            if (lapTimeTotal >= 60)
            {
                lapTimeMinutesTotal++;
                lapTimeTotal = 0;
            }
        }
    }


    void SpawnPlayers()
    {
        for (int i = 0; i < numberOfPlayers; i++)
        {
            Vector3 spawnPosition = startingLine.position; //+ Vector3.right * i;
            GameObject player = Instantiate(playerPrefab, spawnPosition, startingLine.transform.rotation);
            player.GetComponent<PlayerController2>().enabled = false;
            _playersInGame.Add(player);

            foreach (var vCam in allVcams)
            {
                vCam.m_LookAt = player.transform;
                vCam.Follow = player.transform;
            }
        }

        StartCoroutine(CountdownAndStartRace());
    }


    IEnumerator CountdownAndStartRace()
    {
        

        float timer = countdownTime;

        while (timer > 0f)
        {
            if (timer == 3)
                ibg.InitialFadeOutBG();


            countdownText.text = timer.ToString("0");
            yield return new WaitForSeconds(1f);
            timer--;
        }

        SetterRaceInProgess(true);
        countdownText.text = "";
        parentTotalTimeText.SetActive(true);
        EnablePlayerInputs();
    }


    void EnablePlayerInputs()
    {
        foreach (var player in _playersInGame)
        {
            PlayerController2 py2 = player.GetComponent<PlayerController2>();
            py2.enabled = true;
            py2.CanMoveSetter(true);
        }
    }

    bool IsRaceInProgress()
    {
        return raceCurrentlyInProgress;
    }

    private void SetterRaceInProgess(bool value)
    {
        raceCurrentlyInProgress = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            checkpointsPassed++;

            if (checkpointsPassed >= numberOfCheckpoints)
            {
                checkpointsPassed = 0;
            }
        }
    }

    public void PlayerDoneLap()
    {
        lapTimersRecord.Add(TimeSpan.FromSeconds(lapTime));
        lapTime = 0;
        currentLap++;
        StartCoroutine(BestLapChecker());
        if (currentLap > numberOfLaps)
        {
            foreach (var player in _playersInGame)
            {
                PlayerController2 py2 = player.GetComponent<PlayerController2>();
                py2.CanMoveSetter(false);
                py2.enabled = false;
            }

            SetterRaceInProgess(false);
            EndTheRace();
            return;
        }

        lapNumberText.text = currentLap + "/" + numberOfLaps;

        if (currentLap==numberOfLaps)
        {
            StartCoroutine(Coroutine_TurnOnFinishLine());
        }
    }

    private IEnumerator BestLapChecker()
    {
        if (lapTimersRecord.Count == 1)
        {
            lapTimeText.color = Color.green;
        }
        else
        {
            if (lapTimersRecord[lapTimersRecord.Count-1] <
                    lapTimersRecord.Take(lapTimersRecord.Count - 1).OrderBy(x => x.TotalSeconds).First())
                lapTimeText.color = Color.green;
            else
                lapTimeText.color = Color.red;
        }
        lapTimeText.text = lapTimersRecord[lapTimersRecord.Count - 1].ToString(@"mm\:ss\:ff");
        parentLapTimeText.SetActive(true);
        yield return new WaitForSeconds(3);
        parentLapTimeText.SetActive(false);
    }

    private void EndTheRace()
    {
        endPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        float value = float.PositiveInfinity;
        int index = -1;
        for (int i = 0; i < lapTimersRecord.Count; i++)
        {
            if ((lapTimersRecord[i].Seconds + (lapTimersRecord[i].Minutes * 60)) < value)
            {
                index = i;
                value = (lapTimersRecord[i].Seconds + (lapTimersRecord[i].Minutes * 60));

            }
            lapTimeTotalTimer = lapTimeTotalTimer.Add(lapTimersRecord[i]);
            Debug.Log(lapTimeTotalTimer);
            timersEndText[i].text = lapTimersRecord[i].ToString(@"mm\:ss\:ff");
        }

        timerTotalEndText.text = lapTimeTotalTimer.ToString(@"mm\:ss\:ff");
        bestTimerText[index].SetActive(true);
    }

    private IEnumerator Coroutine_TurnOnFinishLine()
    {
        yield return new WaitForSeconds(.5f);
        _finishLine.SetActive(true);
    }
}