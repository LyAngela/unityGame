using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Avatar : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] private float _speed = 8f;

    private void OnMove(InputValue inputValue) {
        _direction = inputValue.Get<Vector2>();
        inputValue.Get<>()
    }

    private void FixedUpdate()
    {
        transform.position += Time.fixedDeltaTime * new Vector3(_direction.x, 0, _direction.y) * _speed;
    }
    
    
}
