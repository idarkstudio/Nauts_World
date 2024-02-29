using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTableManager : MonoBehaviour
{
    [SerializeField] private List<EndTableSetter> positions = new List<EndTableSetter>();

    public void SetterAllTables(List<string> names, List<TimeSpan> totalTimers, List<TimeSpan> bestTimes)
    {
        for (int i = 0; i < positions.Count; i++)
        {
            positions[i].SetterInfo(names[i], totalTimers[i],bestTimes[i]);
        }
    }
}
