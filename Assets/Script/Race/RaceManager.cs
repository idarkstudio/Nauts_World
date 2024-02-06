using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RaceManager : MonoBehaviour
{

    [SerializeField] private Transform startingLine;
    [SerializeField] private GameObject playerPrefab;


    private bool raceCurrentlyInProgress;

    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private float countdownTime = 5f;

    [SerializeField] private TextMeshProUGUI lapTimeText;
    [SerializeField] private float lapTime = 0f;
    [SerializeField] private float lapTimeMinutes = 0f;
    [SerializeField] private List<TimeSpan> lapTimersRecord = new List<TimeSpan>();

    [SerializeField] private TextMeshProUGUI lapNumberText;
    [SerializeField] private int numberOfLaps = 3;
    [SerializeField] private int currentLap = 1;
    [SerializeField] private int checkpointsPassed = 0;

    [SerializeField] private int numberOfCheckpoints = 4;
    public int numberOfPlayers = 1;

    private List<GameObject> _playersInGame = new List<GameObject>();


    [Header("Ending Timers")]
    [SerializeField] private GameObject endPanel;
    [SerializeField] private List<TextMeshProUGUI> timersText = new List<TextMeshProUGUI>();
    [SerializeField] private List<GameObject> bestTimerText = new List<GameObject>();

    private void Awake()
    {

    }


    void Start()
    {
        SetterRaceInProgess(false);
        SpawnPlayers();
        lapNumberText.text = "Lap " + currentLap + "/" + numberOfLaps;


    }

    void Update()
    {

        if (IsRaceInProgress())
        {
            lapTime += Time.deltaTime;
            lapTimeText.text = lapTimeMinutes.ToString() + ":" + lapTime.ToString("00.00");

            if (lapTime >= 60)
            {
                lapTimeMinutes++;
                lapTime = 0;
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
        }

        StartCoroutine(CountdownAndStartRace());

    }



    IEnumerator CountdownAndStartRace()
    {
        float timer = countdownTime;

        while (timer > 0f)
        {
            countdownText.text = timer.ToString("0");
            yield return new WaitForSeconds(1f);
            timer--;
        }

        SetterRaceInProgess(true);
        EnablePlayerInputs();
    }


    void EnablePlayerInputs()
    {
        foreach (var player in _playersInGame)
        {
            PlayerController2 py2 = player.GetComponent<PlayerController2>();
            py2.enabled = true;
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

        //lapTimersRecord.Add((lapTimeMinutes * 60) + lapTime);
        lapTimersRecord.Add((TimeSpan.FromSeconds(lapTime + (lapTimeMinutes * 60))));
        currentLap++;
        if (currentLap > numberOfLaps)
        {
            foreach (var player in _playersInGame)
            {
                PlayerController2 py2 = player.GetComponent<PlayerController2>();
                py2.enabled = false;
            }
            SetterRaceInProgess(false);
            EndTheRace();
        }
        else
        {
            lapNumberText.text = "Lap " + currentLap + "/" + numberOfLaps;         

            lapTime = 0f;
            lapTimeMinutes = 0f;
        }


    }

    private void EndTheRace()
    {
        endPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        float value = float.PositiveInfinity;
        int index = -1;
        for (int i = 0; i < lapTimersRecord.Count; i++)
        {
            if ((lapTimersRecord[i].Seconds + (lapTimersRecord[i].Minutes*60)) < value)
            {
                index = i;
                value = (lapTimersRecord[i].Seconds + (lapTimersRecord[i].Minutes * 60));
            }
            timersText[i].text = lapTimersRecord[i].ToString(@"mm\:ss\:fff");
        }
        bestTimerText[index].SetActive(true);
    }
}
