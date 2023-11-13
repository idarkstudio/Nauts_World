using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float _speed = 5 ;
    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private float _acceleration;

    Rigidbody _characterRb;

    private float x, z;


    private void Start()
    {
        _characterRb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        MovementLogic();
    }


    private void PlayerMove( float x, float z)
    {
        Vector3 pos = transform.forward * x;

        pos += transform.right * z;
        pos *= _speed = Time.deltaTime;
        pos += transform.up * _characterRb.velocity.y;

        _characterRb.velocity = pos;

    }

    void MovementLogic()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        PlayerMove(x, z);
              



    }








}
