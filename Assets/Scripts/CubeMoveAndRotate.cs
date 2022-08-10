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
    private Camera _mainCamera;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _mainCamera = Camera.main;
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
                _targetPos = _mainCamera.ScreenToWorldPoint(new Vector3(_touch.position.x, _touch.position.y,
                    _mainCamera.nearClipPlane + 5f));
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
