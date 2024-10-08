using UnityEngine;

public class BillboardAnimation : MonoBehaviour
{
    public Animator animator;
    public string triggerParameter = "PlayerNearby";

    private void Start()
    {
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the billboard object.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger area.");
            animator.SetBool(triggerParameter, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited trigger area.");
            animator.SetBool(triggerParameter, false);
        }
    }
}


