using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;

public class LeaderboardManager : MonoBehaviour
{
    public static LeaderboardManager Instance;

    public Score[] tenLap;
    public Score[] tenRace;
    public Score[] scores;
    public Score userScore;

    private void Awake()
    {
        //TODO: Make connection with canvas
        if (Instance!=null)
        {
           Destroy(gameObject);
           return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void CallbackTenLap(string jsonScore)
    {
        try
        {
            tenLap = JsonConvert.DeserializeObject <Score[] > (jsonScore);
            EventManager.Trigger("TenLapCallBack", tenLap, 0);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error deserializing the score: " + ex.Message);
        }

    }
    public void CallbackTenRace(string jsonScore)
    {
        try
        {
            tenRace = JsonConvert.DeserializeObject <Score[] > (jsonScore);
            EventManager.Trigger("TenRaceCallBack", tenRace, 0);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error deserializing the score: " + ex.Message);
        }

    }


    public void CallbackScore(string jsonScore)
    {
        try
        {
            this.userScore = JsonConvert.DeserializeObject<Score>(jsonScore);
            EventManager.Trigger("PlayerScoreCallBack", userScore);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error deserializing the score: " + ex.Message);
        }
    }

    public void CallbackTotalScore(string jsonScore)
    {
        try
        {
            this.scores = JsonConvert.DeserializeObject<Score[]>(jsonScore);
            EventManager.Trigger("TotalScoreCallBack", scores);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error deserializing the score: " + ex.Message);
        }
    }
}

public class Score
{
    private float bestLapTime;
    private float bestRaceTime;
    private string principal;
    private string userName;

    public float BestLapTime
    {
        get => bestLapTime;
        set => bestLapTime = value;
    }

    public float BestRaceTime
    {
        get => bestRaceTime;
        set => bestRaceTime = value;
    }

    public string Principal
    {
        get => principal;
        set => principal = value;
    }

    public string UserName
    {
        get => userName;
        set => userName = value;
    }
}