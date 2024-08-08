using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFixerMainMenu : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float timer;
    [SerializeField] private CinemachineVirtualCamera cameraToChange;

    public void ChangeCameraAim()
    {
       LeanTween.value(cameraToChange.gameObject,
           cameraToChange.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset,
            cameraToChange.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset + offset,
            timer).setOnUpdate((Vector3 val)=> { cameraToChange.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset = val; });
    
    }

    public void ReturnCameraAim()
    {
        LeanTween.value(cameraToChange.gameObject,
            cameraToChange.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset,
             cameraToChange.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset - offset,
             timer).setOnUpdate((Vector3 val) => { cameraToChange.GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset = val; });
    
        }
}
