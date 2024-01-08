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


    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private float countdownTime = 5f;

    [SerializeField] private TextMeshProUGUI lapTimeText;
    [SerializeField] private float lapTime = 0f;

    [SerializeField] private TextMeshProUGUI lapNumberText;
    [SerializeField] private int numberOfLaps = 3;
    [SerializeField] private int currentLap = 0;
    [SerializeField] private int checkpointsPassed = 0;

    [SerializeField] private int numberOfCheckpoints = 4;
    public int numberOfPlayers = 1;


    private void Awake()
    {
        
    }


    void Start()
    {
        SpawnPlayers();

    }

    // Update is called once per frame
    void Update()
    {
        if (IsRaceInProgress())
        {
            lapTime += Time.deltaTime;
            lapTimeText.text = lapTime.ToString("0.000");

          
            if (HasCompletedLap())
            {
                currentLap++;
                lapNumberText.text = "Lap " + currentLap + "/" + numberOfLaps;

                lapTime = 0f;

                // Aquí puedes agregar lógica adicional al completar una vuelta
            }

            if (currentLap >= numberOfLaps)
            {
                //poner algun mensaje o no se..
                Debug.Log("Carrera completada");
            }
        }
    }


    void SpawnPlayers()
    {

        for (int i = 0; i < numberOfPlayers; i++)
        {
            Vector3 spawnPosition = startingLine.position + Vector3.forward * i;
            GameObject player = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
        }

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

        
        EnablePlayerInputs();
    }


    void EnablePlayerInputs()
    {
        
        Debug.Log("Inputs habilitados. ¡Comienza la carrera!");
    }

    bool IsRaceInProgress()
    {
        return true;
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

    bool HasCompletedLap()
    {
       //aca verificaria si se completo una vuelta.. como? poniendo 4 o 5 puntos de checkpoints en la carrera y si los recorre en orden y todos, ahi verifica que se completo una vuelta entera.

        return false;
    }





}
