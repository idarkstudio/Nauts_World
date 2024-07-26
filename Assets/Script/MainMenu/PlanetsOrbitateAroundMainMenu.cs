using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsOrbitateAroundMainMenu : MonoBehaviour
{
    public bool isMouseOver = false;

    [SerializeField] private List<PlanetsMainMenu> planets = new List<PlanetsMainMenu>();
    [SerializeField] private GameObject planetsParent;

    [Header("Movement Properties")]
    [SerializeField] private bool _doesItMove;
    [Space(10)] [SerializeField] private Vector3 _movementValue;

    [Space(10)]
    [Header("Rotation Properties")]
    [SerializeField] private bool _doesItRotate;
    [Space(10)] [SerializeField] private Vector3 _rotationValue;

    void Start()
    {
        
    }



    void Update()
    {
        if (isMouseOver) return;

        if (_doesItMove)
            DoMovement();

        if (_doesItRotate)
            DoRotation();
    }

    void DoRotation()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            planets[i].gameObject.transform.Rotate(_rotationValue * Time.deltaTime);
        }
    }

    void DoMovement()
    {
        planetsParent.transform.Rotate(_movementValue * Time.deltaTime);
    }

    public void EnableCollidersPlanets()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            planets[i].EnableCollider();
        }
    }
    
    public void DisableCollidersPlanets()
    {
        for (int i = 0; i < planets.Count; i++)
        {
            planets[i].DisableCollider();
        }
    }
}
