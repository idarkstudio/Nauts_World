using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float rotationSpeed = 5f;
    public Vector3 regularRotation = Vector3.zero;

    private Quaternion targetRotation;
    private bool playerIsClose = false;
    private Quaternion initialRotation;

    private void Start()
    {
        targetRotation = Quaternion.Euler(regularRotation);
        initialRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        }
    }

    private void Update()
    {
        if (playerIsClose)
        {
            Vector3 playerDirection = playerTransform.position - transform.position;
            playerDirection.y = 0f; // Ignore the y-axis

            if (playerDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(playerDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f), rotationSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
