using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeMoveAndRotate : MonoBehaviour
{
    public float moveSpeed = 1;
    public float rotateSpeed = 1;
    public float rotateDuration = 5;

    [SerializeField] private Vector3 _targetPos;
    
    private Rigidbody _rigidbody;
    private Vector3 _targetRotationVector;
    private float _rotateDone = 0;
    private Touch _touch;
    private float _width;
    private float _height;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _width = (float)Screen.width / 2.0f;
        _height = (float)Screen.height / 2.0f;
        print(_width);
        print(_height);
    }

    private void Start()
    {
        Rotate();
    }

    private void Update()
    {
        MoveToTouch();
        Rotate();
    }

    private void MoveToTouch()
    {
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Began || _touch.phase == TouchPhase.Moved)
            {
                _targetPos = _touch.position;
                _targetPos.x = ((_targetPos.x - _width) / 2.0f) / 100.0f;
                _targetPos.y = ((_targetPos.y - _height) / 2.0f) / 100.0f;
            }
        }
        
        transform.position = Vector3.Lerp(transform.position, _targetPos, moveSpeed * Time.deltaTime);
    }
    
    private void Rotate()
    {
        if (Time.time > _rotateDone)
        {
            _targetRotationVector = Random.insideUnitSphere;
            _rotateDone = Time.time + rotateDuration;
        }
        
        _rigidbody.rotation *= Quaternion.Euler(_targetRotationVector * rotateSpeed);
    }
}
