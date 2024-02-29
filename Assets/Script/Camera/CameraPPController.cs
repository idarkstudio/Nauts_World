using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPPController : MonoBehaviour
{
    [SerializeField] private CustomPostProcessing animeSpeed;

    void Start()
    {
        EventManager.Subscribe(EventNames._PlayerSpeedUp, WingsPPEnabler);
        EventManager.Subscribe(EventNames._SpeedBackToNormal, WingsPPDisabler);
    }

    private void WingsPPEnabler(params object[] parameters)
    {
        animeSpeed.enabled = true;
    }
    
    private void WingsPPDisabler(params object[] parameters)
    {
        animeSpeed.enabled = false;
    }

}
