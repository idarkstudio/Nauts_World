using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class IntensityLightController : MonoBehaviour
{
    public float minValue;
    public float maxValue;
    public bool isIncreasing;
    public float actualValue;

    public bool hasToWait;
    public float waitTime;
    public float actualWaitValue;

    private void Update()
    {
        if (hasToWait)
            actualWaitValue += Time.deltaTime;
        if (actualWaitValue >= waitTime)
            actualWaitValue = 0; hasToWait = false;

        return;
    }
}
