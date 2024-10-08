using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public AutoDoor autoDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            autoDoor.SetPlayerIsHere(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            autoDoor.SetPlayerIsHere(false);
        }
    }
}