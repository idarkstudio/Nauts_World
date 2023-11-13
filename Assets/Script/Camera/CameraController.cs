using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    [SerializeField]
    float speed;



    private void FixedUpdate()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);


    }




}
