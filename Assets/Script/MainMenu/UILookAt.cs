using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAt : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;


    void Update()
    {
        transform.forward = transform.position - mainCamera.transform.position;
        transform.rotation = Quaternion.Euler(transform.rotation.x, 0, transform.rotation.z);
    }
}
