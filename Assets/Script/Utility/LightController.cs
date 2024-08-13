using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private GameObject goToAttach;
    [SerializeField] private Light lightToChange;
    [SerializeField] private float maxLight;
    [SerializeField] private float minLight;
    [SerializeField] private float timer;

    void Start()
    {
        ChangeLightToMax();
    }


    public void ChangeLightToMax()
    {
        LeanTween.value(goToAttach,
           lightToChange.intensity,
            maxLight,
            timer).setOnUpdate((float val) => { lightToChange.intensity = val; }).setOnComplete(() => ChangeLightToMin());
    }

    public void ChangeLightToMin()
    {
        LeanTween.value(goToAttach,
   lightToChange.intensity,
    minLight,
    timer).setOnUpdate((float val) => { lightToChange.intensity = val; }).setOnComplete(() => ChangeLightToMax());
    }
}

