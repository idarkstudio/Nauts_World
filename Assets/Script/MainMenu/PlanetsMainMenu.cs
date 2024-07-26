using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsMainMenu : MonoBehaviour
{
    [SerializeField] private string levelToLoad;
    [SerializeField] private MainMenuController mm;
    [SerializeField] private PlanetsOrbitateAroundMainMenu managerOrbitate;
    [SerializeField] private Transform cameraPos;


    private void OnMouseOver()
    {
        managerOrbitate.isMouseOver = true;
    }

    private void OnMouseExit()
    {
        managerOrbitate.isMouseOver = false;
    }

    private void OnMouseUpAsButton()
    {
        ChangeLevel();
    }

    public void ChangeLevel()
    {
        mm.ChangeLevel(levelToLoad);
    }


}
