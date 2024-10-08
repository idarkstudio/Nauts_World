using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    public GameObject objectToHide;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HideObject();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ShowObject();
        }
    }

    private void HideObject()
    {
        objectToHide.SetActive(false);
    }

    private void ShowObject()
    {
        objectToHide.SetActive(true);
    }
}

