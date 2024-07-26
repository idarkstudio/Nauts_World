using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsMainMenu : MonoBehaviour
{
    [SerializeField] private string levelToLoad;
    [SerializeField] private MainMenuController mm;
    [SerializeField] private PlanetsOrbitateAroundMainMenu managerOrbitate;
    private Collider colliderObject;
    [SerializeField] private GameObject canvasToEnable;
    [SerializeField] private GameObject lightToEnable;


    private void Start()
    {
        colliderObject = GetComponent<Collider>();
    }

    public void EnableCollider()
    {
        colliderObject.enabled = true;
        canvasToEnable.SetActive(true);
    }
    public void DisableCollider()
    {
        colliderObject.enabled = false;
        canvasToEnable.SetActive(false);
    }

    private void OnMouseOver()
    {
        managerOrbitate.isMouseOver = true;
        lightToEnable.SetActive(true);
    }

    private void OnMouseExit()
    {
        managerOrbitate.isMouseOver = false;
        lightToEnable.SetActive(false);
    }

    private void OnMouseUpAsButton()
    {
        if (levelToLoad == null)
            return;
        ChangeLevel();
    }

    public void ChangeLevel()
    {
        mm.ChangeLevel(levelToLoad);
    }


}
