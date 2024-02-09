using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController2 : MonoBehaviour
{
    [SerializeField] private CharacterSO so;

    [SerializeField] private Rigidbody _sphereRigidbody;

    [SerializeField] private float _curentSpeed;
    [SerializeField] private float _topSpeed;
    [SerializeField] private float _accelerationSpeed;
    [SerializeField] private float _maxFloatHeight = 10;
    [SerializeField] private float _forwardSpeed;
    private float _baseForwardSpeed;
    [SerializeField] private float _forwardAcceleration;
    [SerializeField] private float _turnAmount;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _deceleratiionSpeed = 20;
    [Range(0,1)] [SerializeField] private float _crashSpeedPercentage;
    [SerializeField] private float _maxAirborneTime;


    [Header("Model")]
    [SerializeField] private LayerMask _groundLayerMask;

    [SerializeField] private Animator _animator;
    [SerializeField] private List<Material> mats = new List<Material>();
    [SerializeField] private GameObject modelChar;

    public bool _isGrounded;
    private bool _isDescending;
    private bool _isFlying =  false; 
    private float _forwardAmount;
    public float _descentSpeed = 5f;
    public float _airborneTime;    
    private float _initialJumpForce = 10f;

    [Header("Speed Pads")]
    [SerializeField] private float extraSpeedUpPad;
    [SerializeField] private float extraSpeedDownPad;

    private void Awake()
    {
        modelChar.GetComponent<Renderer>().material = mats[so.numberMat];
        _curentSpeed = 0f;
        _baseForwardSpeed = _forwardSpeed;
    }

    void Start()
    {

        _sphereRigidbody.transform.parent = null;

    }

     
    void Update()
    {

        transform.position = _sphereRigidbody.transform.position;

        _forwardAmount = Input.GetAxis("Vertical");
        _turnAmount = Input.GetAxis("Horizontal");


        if (Input.GetKeyDown(KeyCode.W) && _isGrounded)
        {
            _isFlying = true;
            _animator.SetBool("Flying", _isFlying);
            
        }
        else if (Input.GetKeyUp(KeyCode.W) && _isGrounded)
        {
            _isFlying = false;
            _animator.SetBool("Flying", _isFlying);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
        {
            DriveDeceleration();
        }

        if (_forwardAmount != 0 && _isGrounded )
        {

            Drive();
           
           /* if (Input.GetKey(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
            {
                DriveDeceleration();               
            }
           */
          
        }
        else _forwardSpeed = _baseForwardSpeed;
       
       

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (_isGrounded ==  false)
        {


        }

        TurnHandler();
        GroundCheckAndNormalHandler();
    }

    private void FixedUpdate()
    {
       
       _sphereRigidbody.AddForce(transform.forward * _curentSpeed, ForceMode.Acceleration);
        //_animator.SetTrigger("IsFlying");
        

    }

    
    private void Drive()
    {
        _curentSpeed = _forwardAmount *= _forwardSpeed;
        
        if(_forwardAmount != 0) AccelerationBuildup();
    }
 

    private void TurnHandler()
    {
        float newRotation = _turnAmount * _turnSpeed * Time.deltaTime;
        if (_curentSpeed > 0.1f) transform.Rotate(0, newRotation, 0, Space.World);
        
    }
    
    private void DriveDeceleration()
    {
        _curentSpeed = Mathf.MoveTowards(_curentSpeed, 0f, _deceleratiionSpeed * Time.deltaTime);
    }

    private void AccelerationBuildup()
    {
        _forwardSpeed = Mathf.MoveTowards(_forwardSpeed, _topSpeed, _accelerationSpeed * Time.deltaTime);
    }

    private void GroundCheckAndNormalHandler()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 3 , _groundLayerMask))
        {
            _isGrounded = true;
            _airborneTime = 0f; // Reinicia el tiempo en el aire
        }
        else
        {
            _isGrounded = false;
            _airborneTime += Time.deltaTime;

            if (_airborneTime > _maxAirborneTime)
            {
                // Empieza a descender el personaje si ha estado en el aire m s de 5 segundos
                Descend();
            }
        }

        Debug.Log(_isGrounded + " booleano ");

        if (_isGrounded)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation, 0.1f);
        }
    }


    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (-transform.up));
       
    }

    private void Jump() 
    {
        _sphereRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse); 
    }

    private void Descend()
    {
        if (!_isDescending)
        {
            // Aplica una fuerza inicial hacia arriba para simular el impulso inicial
            _sphereRigidbody.AddForce(Vector3.up * _initialJumpForce, ForceMode.Impulse);
            _isDescending = true;
        }

        // Aplica la fuerza de la gravedad para que el personaje comience a descender
        _sphereRigidbody.AddForce(Vector3.down * _sphereRigidbody.mass * Physics.gravity.magnitude);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            _topSpeed += extraSpeedUpPad;
        }
        else if (other.gameObject.layer == 12)
        {
            _topSpeed += extraSpeedDownPad;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 13)
        {
            _curentSpeed *= _crashSpeedPercentage;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            _topSpeed = _baseForwardSpeed;
            return;
        }
        
        if (other.gameObject.layer == 12)
        {
            _topSpeed = _baseForwardSpeed;
            return;
        }
        
        if (other.gameObject.layer == 13)
        {
            _curentSpeed *= _crashSpeedPercentage;
            return;
        }
    }

}
