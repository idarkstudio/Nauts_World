using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinnigWheel : MonoBehaviour
{
    [SerializeField] private GameObject spinningWheel;
    [SerializeField] float speedRotation;

    void Update()
    {
        spinningWheel.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, speedRotation * Time.deltaTime));
    }
}
