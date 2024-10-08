using UnityEngine;

public class ZeroGravityZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleGravity(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ToggleGravity(true);
        }
    }

    private void ToggleGravity(bool enableGravity)
    {
        Rigidbody[] allRigidbodies = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody rb in allRigidbodies)
        {
            if (rb.CompareTag("Player"))
            {
                rb.useGravity = enableGravity;
            }
        }
    }
}



