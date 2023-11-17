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
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _deceleratiionSpeed = 20;
    [SerializeField] private float _maxAirborneTime;


    [SerializeField] private LayerMask _groundLayerMask;



    private bool _isGrounded;
    private bool _isDescending;
    private float _forwardAmount;
    public float _descentSpeed = 5f;
    public float _airborneTime;    
    private float _initialJumpForce = 10f;


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
            if (Input.GetKey(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
            {
                DriveDeceleration();
            }           
        }

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
    
    private void DriveDeceleration()
    {
        _curentSpeed = Mathf.MoveTowards(_curentSpeed, 0f, _deceleratiionSpeed * Time.deltaTime);
    }


    private void GroundCheckAndNormalHandler()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 2, _groundLayerMask))
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
                // Empieza a descender el personaje si ha estado en el aire más de 5 segundos
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

}
