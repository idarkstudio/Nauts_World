using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemManager : MonoBehaviour
{
    [SerializeField] private List<Transform> boxPositions = new List<Transform>();
    [SerializeField] private List<GameObject> boxObjects = new List<GameObject>();
    [SerializeField] private float timerRespawn;

    [SerializeField] private PlayerController2 player;


    private void Start()
    {
        StartCoroutine(WaitForPlayer());
    }

    IEnumerator WaitForPlayer()
    {
        yield return new WaitForSecondsRealtime(6);
        player = FindObjectOfType<PlayerController2>();
    }

    public void PlayerCollectedItem(GameObject go, ItemsSO so)
    {
        StartCoroutine(RespawnItem(go));
        player.PlayerGrabItem(so);
    }

    IEnumerator RespawnItem(GameObject itemToRespawn)
    {
        yield return new WaitForSecondsRealtime(timerRespawn);
        itemToRespawn.SetActive(true);
    }
}
