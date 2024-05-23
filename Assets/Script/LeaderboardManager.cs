using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;

public class LeaderboardManager : MonoBehaviour
{
    public List<Score> scores;
    public Score userScore;

   public void GetScore(string jsonScore)
   {
            try
            {
            // aca se puede hacer un evento cada vez que llegue esto que se actualice el score 
                this.userScore = JsonConvert.DeserializeObject<Score>(jsonScore);
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error deserializing the score: " + ex.Message);
            }            
   }

    public void GetTotalScore(string jsonScore)
    {
        try
        {
            this.scores = JsonConvert.DeserializeObject<List<Score>>(jsonScore);
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

    public float BestLapTime { get => bestLapTime; set => bestLapTime = value; }
    public float BestRaceTime { get => bestRaceTime; set => bestRaceTime = value; }
    public string Principal { get => principal; set => principal = value; }
    public string UserName { get => userName; set => userName = value; }
}