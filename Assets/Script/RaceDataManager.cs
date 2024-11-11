using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RaceDataManager : MonoBehaviour
{
    [SerializeField]
    private RaceManager raceManager;

    private string principal;
    private int totalRaceTimeMs;
    private int bestLapTimeMs;
    private string mainMenu = "mainmenu";

    private const string urlSetBestTimes = "";





    public void ReturnToMainMenu()
    {
        if (!raceManager.IsRaceInProgress())//booleano de si termino a carrera
        {
            totalRaceTimeMs = raceManager.TotalRaceTimeMs;
            bestLapTimeMs = raceManager.BestLapTimeMs;

            var raceData = new Dictionary<string, object>
            {
                { "principal", principal },
                { "bestRaceTime", totalRaceTimeMs },
                { "bestLapTime", bestLapTimeMs }
            };

            StartCoroutine(SendRequest(urlSetBestTimes, raceData));
        }
        else
        {
            ReacFunctions.ReturnToMainMenu(mainMenu);

        }
    }


    private IEnumerator SendRequest(string url, Dictionary<string, object> jsonData)
    {
        string jsonString = JsonUtility.ToJson(jsonData);// JsonUtility.ToJson(new SerializableData(jsonData));
        UnityWebRequest request = new(url, jsonString);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Datos enviados con �xito: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Error al enviar los datos: " + request.error);
        }
    }
   
}