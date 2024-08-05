using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnButtonsHover : MonoBehaviour
{
    [SerializeField] private GameObject textToDisplay;


    public void OnMouseEnter()
    {
        textToDisplay.SetActive(true);
    }

    public void OnMouseExit()
    {
        textToDisplay.SetActive(false);
    }

    public void CloseText()
    {
        textToDisplay.SetActive(false);
    }
}
