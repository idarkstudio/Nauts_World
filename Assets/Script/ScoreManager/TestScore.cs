using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestScore : MonoBehaviour
{
    private void Awake()
    {
        EventManager.Subscribe("PlayerScoreCallBack", CB_MyScore);
        EventManager.Subscribe("TotalScoreCallBack", CB_TotalScore);
        EventManager.Subscribe("TenLapCallBack", CB_TenLapScore);
        EventManager.Subscribe("TenRaceCallBack", CB_TenRaceScore);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            var lapTime = Random.Range(0f, 20f);
            ReacFunctions.SetLapTime(lapTime);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            var raceTime = Random.Range(0f, 20f);
            ReacFunctions.SetRaceTime(raceTime);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ReacFunctions.GetScore();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ReacFunctions.GetTotalScore();
        }
        
        if (Input.GetKeyDown(KeyCode.G))
        {
            ReacFunctions.GetTenLap();
        }
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            ReacFunctions.GetTenRace();
        }
    }

    private void CB_TotalScore(params object[] parameters)
    {
        Debug.Log("Total Score");
        
        var scores = parameters.OfType<Score>();

        if (!scores.Any()) return;
        
        foreach (var score in scores)
        {
            Debug.Log(score.UserName);
            Debug.Log(score.Principal);
            Debug.Log(score.BestLapTime);
            Debug.Log(score.BestRaceTime);
            Debug.Log("-----------------------------------");
        }
    }
    
    private void CB_TenRaceScore(params object[] parameters)
    {
        Debug.Log("Ten Race Score");
        
        var scores = parameters.OfType<Score>();

        if (!scores.Any()) return;
        
        foreach (var score in scores)
        {
            Debug.Log(score.UserName);
            Debug.Log(score.Principal);
            Debug.Log(score.BestLapTime);
            Debug.Log(score.BestRaceTime);
            Debug.Log("-----------------------------------");
        }
    }

    
    private void CB_TenLapScore(params object[] parameters)
    {
        Debug.Log("Ten Lap Score");
        
        var scores = parameters.OfType<Score>();

        if (!scores.Any()) return;
        
        foreach (var score in scores)
        {
            Debug.Log(score.UserName);
            Debug.Log(score.Principal);
            Debug.Log(score.BestLapTime);
            Debug.Log(score.BestRaceTime);
            Debug.Log("-----------------------------------");
        }
    }


    private void CB_MyScore(params object[] parameters)
    {
        Debug.Log("Player Score");
        
        var playerScore = (Score)parameters[0];
        
        Debug.Log(playerScore.UserName);
        Debug.Log(playerScore.Principal);
        Debug.Log(playerScore.BestLapTime);
        Debug.Log(playerScore.BestRaceTime);
    }
}