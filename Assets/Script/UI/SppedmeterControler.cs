using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SppedmeterControler : MonoBehaviour
{
    [SerializeField] private Image dial;
    [SerializeField] private RectTransform posToRotate;

    [SerializeField] private float minSpeedAngle;
    [SerializeField] private float maxSpeedAngle;
    [SerializeField] private float maxSpeed;

    [SerializeField] private PlayerController2 player => FindObjectOfType<PlayerController2>();

    void Update()
    {
        if (player)
        {
            float speedPlayer = player.GetComponent<Rigidbody>().velocity.magnitude;
            float speedNormalized = Mathf.Clamp01(speedPlayer / maxSpeed);
            float targetAngle = Mathf.Lerp(minSpeedAngle, maxSpeedAngle, speedNormalized);
            posToRotate.eulerAngles = new Vector3(0, 0, targetAngle);
        }
    }
}
