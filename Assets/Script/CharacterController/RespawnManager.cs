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
    [SerializeField]
    private LayerMask _deathZoneLayer;

    [SerializeField]
    private Collider map;

    public PlayerController2 _playerController;
    [SerializeField] private Rigidbody _sphereRigidbody;
  
    void Update()
    {
        Timer();
    }

    private void Timer()
    {
        _timer += Time.deltaTime;       
     
          if (_timer >= _saveInterval && _playerController._isGrounded == true)
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
            Debug.Log("deberia hacer el respawnplayer");
            RespawnPlayer();
        }
    }

    private void RespawnPlayer()
    {
        _playerController.enabled=false;
        this.transform.position = _lastSavedPos;
        _sphereRigidbody.velocity = Vector3.zero;
        _sphereRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        StartCoroutine(RespawnCoroutine());
        Debug.Log("deberia ir a la posicion");

    }

    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(1f);
        _playerController.enabled=true;
        _sphereRigidbody.constraints = RigidbodyConstraints.None;
        _sphereRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }
}
