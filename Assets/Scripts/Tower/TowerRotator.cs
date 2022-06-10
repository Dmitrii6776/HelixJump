using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRotator : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 5f;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                var torque = touch.deltaPosition.x * Time.deltaTime * _rotateSpeed;
                _rigidbody.AddTorque(Vector3.up * torque);
            }
        }
    }
}
