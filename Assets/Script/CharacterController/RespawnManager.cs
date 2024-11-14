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

    private PlayerController2 _playerController;
    [SerializeField] private Rigidbody _sphereRigidbody;

    [SerializeField] private LapManager lp;
    [SerializeField] private Transform lastPosSaved;
    [SerializeField] private Transform lastLookAtSaved;
    private InitialBackground ibg;

    private void Awake()
    {
        lastPosSaved.parent = null;
    }

    private void Start()
    {
        lp = FindObjectOfType<LapManager>();
        ibg = FindObjectOfType<InitialBackground>();
        _playerController = FindObjectOfType<PlayerController2>();
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Deathzone"))
        {
            Debug.Log("deberia hacer el respawnplayer");
            ibg.FadeInBG();
            StartCoroutine(RespawnPlayer());
        }
    }

    public void ForceRespawnPlayer()
    {
        ibg.FadeInBG();
        StartCoroutine(RespawnPlayer());
    }

    private IEnumerator RespawnPlayer()
    {
        _playerController.CanMoveSetter(false);
        _playerController.StopVelocity();
        yield return new WaitForSeconds(0.5f);
        _playerController.enabled = false;
        this.transform.position = lastPosSaved.position;
        transform.LookAt(lastLookAtSaved);
        _sphereRigidbody.velocity = Vector3.zero;
        _sphereRigidbody.constraints = RigidbodyConstraints.FreezeAll;
        StartCoroutine(RespawnCoroutine());
        Debug.Log("deberia ir a la posicion");
    }

    private IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        ibg.FadeOutBG();
        _playerController.enabled=true;
        _playerController.CanMoveSetter(true);
        _playerController._forwardSpeed = 0;
        _sphereRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void SaveLastPost(Transform lastPos, Transform lookRot)
    {
        lastPosSaved.position = lastPos.position;
        lastLookAtSaved = lookRot;
    }
}
