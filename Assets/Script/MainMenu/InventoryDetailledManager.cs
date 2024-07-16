using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDetailledManager : MonoBehaviour
{
    [SerializeField] private InventoryDetaillerCollectionSetter[] nautsCollection = new InventoryDetaillerCollectionSetter[16];

    private void Awake()
    {
        EventManager.Subscribe("NFTCallback", SetterBla);
    }

    private void SetterBla(params object[] parameters)
    {
        var data = (NFTData[])parameters[0];

        for (int i = 0; i < data.Length; i++)
        {
            nautsCollection[i].SetterProfileFromLap(data[i]);
        }
    }
}
