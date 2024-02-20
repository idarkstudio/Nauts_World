using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EnvironmentRotation : MonoBehaviour
{
    [Header("Movement Properties")]
    [SerializeField] private bool _doesItMove;
    [Space(10)] [SerializeField] private float _timeToMove;
    [Space(10)] [SerializeField] private Vector3 _startValue;
    [SerializeField] private Vector3 _endValue;

    private Vector3 _startPosition, _endPosition;
    private Vector3 _currentPositionToMove;
    private float _elapsedTime;

    [Space(10)] [Header("Rotation Properties")]
    [SerializeField] private bool _doesItRotate;
    [Space(10)] [SerializeField] private Vector3 _rotationValue;


    private void Start()
    {
        _startPosition = transform.position + _startValue;
        _endPosition = transform.position + _endPosition;
        
        _currentPositionToMove = _endPosition;
    }

    private void Update()
    {
        if(_doesItRotate)
            DoRotation();
        
        if(_doesItMove)
            DoMovement();
    }

    void DoRotation()
    {
        transform.Rotate(_rotationValue * Time.deltaTime);
    }

    void DoMovement()
    {
        _elapsedTime += Time.deltaTime;
        float percentageComplete = _elapsedTime / _timeToMove;
        
        transform.position = Vector3.Lerp(transform.position, _currentPositionToMove, Mathf.SmoothStep(0, 1, percentageComplete));

        if (percentageComplete >= 0.2f)
        {
            ChangePosition();
            _elapsedTime = 0f;
        }
    }

    void ChangePosition()
    {
        if (_currentPositionToMove == _endPosition)
            _currentPositionToMove = _startPosition;
        else _currentPositionToMove = _endPosition;
    }
}
