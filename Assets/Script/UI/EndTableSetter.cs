using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EndTableSetter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI totalTimeText;
    [SerializeField] private TextMeshProUGUI bestTimeText;

    public void SetterInfo(string nameValue, TimeSpan totalTimeValue, TimeSpan bestTimeValue)
    {
        nameText.text = nameValue;
        totalTimeText.text = totalTimeValue.ToString(@"mm\:ss\:ff");
        bestTimeText.text = bestTimeValue.ToString(@"mm\:ss\:ff");
    }
}
