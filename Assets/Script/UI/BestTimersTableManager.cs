using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTimersTableManager : MonoBehaviour
{
    [SerializeField] private List<BestTimersSetters> positions = new List<BestTimersSetters>();
    [SerializeField] private List<GameObject> planets = new List<GameObject>();
    [SerializeField] private BestTimersSetters playerPosition;
    [SerializeField] private Button backButton;
    [SerializeField] private Button forwardButton;
    private int pageNumber = 1;
    int panelsPerPage;
    int totalPagePanels;
    //Some kind of SO to save the list 

    private void Start()
    {
        panelsPerPage = positions.Count * pageNumber;
        //totalPanels = the SO.count / positions.Count;
    }

    //TODO: Change with a JSON or something better than 4 lists and modify the list with and offsett of the page number
    public void SetterAllTables(List<int> positionsOnTable , List<string> names, List<TimeSpan> totalTimers, List<TimeSpan> bestTimes)
    {
        if (pageNumber == 1)
            backButton.gameObject.SetActive(false);
        else
            backButton.gameObject.SetActive(true);

        if (pageNumber == totalPagePanels)
             forwardButton.gameObject.SetActive(false);
        else
            forwardButton.gameObject.SetActive(true);

        for (int i = 0 + panelsPerPage; i < positions.Count + panelsPerPage; i++)
        {
            positions[i].SetterInfo(positionsOnTable[i], names[i], totalTimers[i], bestTimes[i]);
        }

        SetterPlayer();
    }

    public void ChangePage(int value)
    {
        pageNumber += value;
        panelsPerPage = positions.Count * pageNumber;
        //SetterAllTables();
    }

    private void SetterPlayer()
    {
        //playerPosition.SetterInfo();
    }

    public void ChangePlanet()
    {
        //Here we change the SO for the planet
        //SetterAllTables();
        SetterPlayer();
        pageNumber = 1;
    }
}
