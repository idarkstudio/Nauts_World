using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private GameObject parentItem;
    [SerializeField] private Image itemUI;

    public void SetImageUI(ItemsSO so)
    {
        parentItem.SetActive(true);
        itemUI.sprite = so.icon;
    }

    public void PlayerUsedItem()
    {
        parentItem.SetActive(false);
        itemUI.sprite = null;
    }
}
