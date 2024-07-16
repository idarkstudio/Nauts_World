using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardProfiler : MonoBehaviour
{
    [SerializeField] private Image nautsPhoto;
    [SerializeField] private TMP_Text nameNauts;
    [SerializeField] private TMP_Text time;

    public void SetterProfileFromLap(Score playerToSet)
    {
        //nautsPhoto.sprite = 
        nameNauts.text = playerToSet.UserName;
        time.text = playerToSet.BestLapTime.ToString("F2") + "s";
    }
    
    public void SetterProfileFromRace(Score playerToSet)
    {
        //nautsPhoto.sprite = 
        nameNauts.text = playerToSet.UserName;
        time.text = playerToSet.BestRaceTime.ToString("F2") + "s";
    }
}
