using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Avatar : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _rotationSpeed = 90f; // Rotation speed in degrees per second

    private Rigidbody _rigidbody;
    private bool _toJump = false;
    private PhysicMaterial _bounciness;
    public bool IsHighJumping { get; set; }

    public bool OnFloor { get; set; }
    
    

    

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _bounciness = GetComponent<Collider>().material;
        IsHighJumping = false;
        
    }

    private void OnMove(InputValue inputValue)
    {
        _direction = inputValue.Get<Vector2>();
    }
    
    private void OnJump()
    {
        _toJump = true;
    }
    private void OnCollisionEnter(Collision other) {
        
        if (other.collider.CompareTag("Floor")) {
            _bounciness.bounceCombine = PhysicMaterialCombine.Maximum;
            IsHighJumping = false;
            OnFloor = true;
            
        }
        
    }
    
    
    
    private void FixedUpdate()
    {
        // only allowed to jump when hits floor (no double jumps)
        if (_toJump && OnFloor)
        {
            _rigidbody.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            IsHighJumping = true;
            _toJump = false;
        }

        if (IsHighJumping)
        {
            _bounciness.bounceCombine = PhysicMaterialCombine.Average;
        }

        if (transform.position.y > 0)
        {
            OnFloor = false;
        }
        
     
 
        // Calculate movement vector
        Vector3 movement = new Vector3(_direction.x, 0, _direction.y) * _speed * Time.fixedDeltaTime;

        // Move the avatar
        transform.Translate(movement);
        
        // Rotate the avatar
        float rotationAmount = _direction.x * _rotationSpeed * Time.fixedDeltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
      
    }

   
    
   
}