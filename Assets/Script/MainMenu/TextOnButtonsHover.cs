using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextOnButtonsHover : MonoBehaviour
{
    [SerializeField] private GameObject textToDisplay;


    public void OnMouseEnter()
    {
        Debug.Log(666);
        textToDisplay.SetActive(true);
    }

    private void OnMouseOver()
    {
        Debug.Log(555);
        textToDisplay.SetActive(true);
    }

    private void OnMouseDown()
    {
        Debug.Log(444);
        textToDisplay.SetActive(true);
    }

    public void OnMouseExit()
    {
        Debug.Log(777);
        textToDisplay.SetActive(false);
    }

    public void CloseText()
    {
        textToDisplay.SetActive(false);
    }
}
