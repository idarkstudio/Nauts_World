using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField] private ItemsSO itemSO;
    [SerializeField] private PickUpItemManager itemManager;
    [SerializeField] private Animator _anim;

    private void Start()
    {
        _anim.ResetTrigger("PickedUp");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            _anim.SetTrigger("PickedUp");
        }
    }

    private void DesactivateItem()
    {
        itemManager.PlayerCollectedItem(this.gameObject, itemSO);
        this.gameObject.SetActive(false);
    }
}
