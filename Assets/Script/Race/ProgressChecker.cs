using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressChecker : MonoBehaviour
{
    [SerializeField] private bool isFinishLine = false;
    [SerializeField] private bool hasPlayerPassed = false;
    [SerializeField] private LapManager lp;

    void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            hasPlayerPassed = true;
            if (isFinishLine)
                lp.CheckForLap();
        }
    }

    public void Reseter()
    {
        hasPlayerPassed = false;
    }

    public bool GetterPlayerPassed()
    {
        return hasPlayerPassed;
    }
}
