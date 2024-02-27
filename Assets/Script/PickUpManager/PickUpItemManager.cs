using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItemManager : MonoBehaviour
{
    [SerializeField] private List<Transform> boxPositions = new List<Transform>();
    [SerializeField] private List<GameObject> boxObjects = new List<GameObject>();
    [SerializeField] private float timerRespawn;


    public void PlayerCollectedItem(GameObject go, ItemsSO so)
    {
        StartCoroutine(RespawnItem(go));
    }

    IEnumerator RespawnItem(GameObject itemToRespawn)
    {
        yield return new WaitForSecondsRealtime(timerRespawn);
        itemToRespawn.SetActive(true);
    }
}
