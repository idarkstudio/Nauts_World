using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] private Rigidbody _sphereRigidbody;

    [SerializeField] private float _curentSpeed;
    [SerializeField] private float _maxFloatHeight = 10;
    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _turnAmount;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private LayerMask _groundLayerMask;



    private bool _isGrounded = true;
    private float _forwardAmount;
                     

    void Start()
    {
        _sphereRigidbody.transform.parent = null;
    }

     
    void Update()
    {

        transform.position = _sphereRigidbody.transform.position;

        _forwardAmount = Input.GetAxis("Vertical");
        _turnAmount = Input.GetAxis("Horizontal");

        if (_forwardAmount != 0 && _isGrounded)
        {
            Drive();            
           
        }
       

        TurnHandler();
        GroundCheckAndNormalHandler();
    }

    private void FixedUpdate()
    {
       
       _sphereRigidbody.AddForce(transform.forward * _curentSpeed, ForceMode.Acceleration);

      
    }


    private void Drive()
    {
        _curentSpeed = _forwardAmount *= _forwardSpeed;

    }
 

    private void TurnHandler()
    {
        float newRotation = _turnAmount * _turnSpeed * Time.deltaTime;
        if (_curentSpeed > 0.1f) transform.Rotate(0, newRotation, 0, Space.World);
        
    }
    
    private void DriveDesaceleration()
    {

        _curentSpeed = _forwardAmount *= (_forwardSpeed *-1);
    }


    private void GroundCheckAndNormalHandler()
    {
        RaycastHit hit;
        _isGrounded =  Physics.Raycast(transform.position, transform.up * -1, out hit, 1, _groundLayerMask);
        Debug.Log( _isGrounded+ " booleano ");

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation, 0.1f);
    }


    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.up * -1);
       
    }



}
