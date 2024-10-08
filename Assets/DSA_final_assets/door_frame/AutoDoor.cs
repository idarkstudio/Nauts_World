using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public Transform movingDoor1;
    public Transform movingDoor2;
    public Collider frameCollider;
    public float maximumOpening = 10f;
    public float openSpeed = 1f;
    public float closeSpeed = 1f;
    private Vector3 initialPosition1;
    private Vector3 initialPosition2;
    private Vector3 targetPosition1;
    private Vector3 targetPosition2;
    private bool playerIsHere;
    private bool doorsOpen;

    private void Start()
    {
        initialPosition1 = movingDoor1.position;
        initialPosition2 = movingDoor2.position;
        targetPosition1 = initialPosition1 + new Vector3(maximumOpening, 0f, 0f);
        targetPosition2 = initialPosition2 - new Vector3(maximumOpening, 0f, 0f);
        playerIsHere = false;
        doorsOpen = false;
    }

    private void Update()
    {
        if (playerIsHere && !doorsOpen)
        {
            OpenDoors();
        }
        else if (!playerIsHere && doorsOpen)
        {
            CloseDoors();
        }
    }

    private void OpenDoors()
    {
        movingDoor1.position = Vector3.MoveTowards(movingDoor1.position, targetPosition1, openSpeed * Time.deltaTime);
        movingDoor2.position = Vector3.MoveTowards(movingDoor2.position, targetPosition2, openSpeed * Time.deltaTime);

        if (movingDoor1.position == targetPosition1 && movingDoor2.position == targetPosition2)
        {
            doorsOpen = true;
        }
    }

    private void CloseDoors()
    {
        movingDoor1.position = Vector3.MoveTowards(movingDoor1.position, initialPosition1, closeSpeed * Time.deltaTime);
        movingDoor2.position = Vector3.MoveTowards(movingDoor2.position, initialPosition2, closeSpeed * Time.deltaTime);

        if (movingDoor1.position == initialPosition1 && movingDoor2.position == initialPosition2)
        {
            doorsOpen = false;
        }
    }

    public void SetPlayerIsHere(bool isHere)
    {
        playerIsHere = isHere;
    }
}



