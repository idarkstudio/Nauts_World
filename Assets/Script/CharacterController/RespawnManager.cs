using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{

    private Vector3 _lastSavedPos;
    private float _saveInterval = 2f;
    private float _timer = 0f;
    [SerializeField]
    private LayerMask _groundLayer;



    void Update()
    {
        _timer += Time.deltaTime;
       
        if (_timer >= _saveInterval)
        {
            _lastSavedPos = this.transform.position;
            _timer = 0f;
            Debug.Log(" Guarde pos ");
        }
    }

    private void Timer()
    {
        _timer += Time.deltaTime;
        Debug.Log(_timer);
     
          if (_timer >= _saveInterval)
          {
              _lastSavedPos = this.transform.position;
              _timer = 0f;
              Debug.Log(" Guarde pos ");
          }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Deathzone"))
        {
            RespawnPlayer();
        }
    }

    private void RespawnPlayer()
    {

        this.transform.position = _lastSavedPos;
        Debug.Log("deberia ir a la posicion");

    }
}
