using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapManager : MonoBehaviour
{
    [SerializeField] private List<ProgressChecker> checkpoints = new List<ProgressChecker>();
    [SerializeField] private RaceManager rm;

    public void CheckForLap()
    {
        if (checkpoints.All(x => x.GetterPlayerPassed()))
        {
            for (int i = 0; i < checkpoints.Count; i++)
            {
                checkpoints[i].Reseter();
            }

            rm.PlayerDoneLap();
        }
    }
}
