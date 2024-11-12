using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;


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
            // princial =  obtener el player porq si no volvera vacio?
            totalRaceTimeMs = raceManager.TotalRaceTimeMs;
            bestLapTimeMs = raceManager.BestLapTimeMs;

            var raceData = new Dictionary<string, object>
            {
                { "principal", principal },
                { "bestRaceTime", totalRaceTimeMs },
                { "bestLapTime", bestLapTimeMs }
            };

            string jsonData = JsonConvert.SerializeObject(raceData);
            ReacFunctions.SetBestTimes(jsonData);
        }
        else
        {
            ReacFunctions.ReturnToMainMenu(mainMenu);

        }
    }

    /*
    private IEnumerator SendRequest(string url, Dictionary<string, object> jsonData)
    {
        string jsonString = JsonConvert.SerializeObject(jsonData);
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
   */
}
