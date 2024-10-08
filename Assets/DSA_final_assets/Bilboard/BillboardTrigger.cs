using UnityEngine;

public class BillboardTrigger : MonoBehaviour
{
    public Animator animator;
    public string closingAnimationName = "Idle";
    public string openingAnimationName = "IdleOpen";

    private bool playerIsClose = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            animator.Play(openingAnimationName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            animator.Play(closingAnimationName);
        }
    }

    private void Update()
    {
        if (playerIsClose && !animator.GetCurrentAnimatorStateInfo(0).IsName(openingAnimationName))
        {
            animator.Play(openingAnimationName);
        }
        else if (!playerIsClose && !animator.GetCurrentAnimatorStateInfo(0).IsName(closingAnimationName))
        {
            animator.Play(closingAnimationName);
        }
    }
}





