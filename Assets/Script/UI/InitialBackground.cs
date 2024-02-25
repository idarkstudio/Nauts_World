using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialBackground : MonoBehaviour
{
    [SerializeField] private CanvasGroup bg;
    [SerializeField] private float timerIn;
    [SerializeField] private float timerOut;


    public void FadeInBG()
    {
        LeanTween.alphaCanvas(bg, 1, timerIn);
    }
    public void FadeOutBG()
    {
        LeanTween.alphaCanvas(bg, 0, timerOut);
    }
}
