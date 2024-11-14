using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapManager : MonoBehaviour
{
    [SerializeField] private List<ProgressChecker> checkpoints = new List<ProgressChecker>();
    [SerializeField] private RaceManager rm;
    [SerializeField] private RespawnManager respawn => FindObjectOfType<RespawnManager>();

    private void Start()
    {
        
    }

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

    public void SaveNewRespawnPoint(Transform positionToSpawn, Transform RotationToLook)
    {
        respawn.SaveLastPost(positionToSpawn, RotationToLook);
    }
    
    public void ForceRespawnPlayer()
    {
        respawn.ForceRespawnPlayer();
    }
}
