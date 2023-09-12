using UnityEngine;
using UnityEngine.InputSystem;

public class Avatar : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _rotationSpeed = 90f; // Rotation speed in degrees per second

    private void OnMove(InputValue inputValue)
    {
        _direction = inputValue.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        // Calculate movement vector
        Vector3 movement = new Vector3(_direction.x, 0, _direction.y) * _speed * Time.fixedDeltaTime;

        // Move the avatar
        transform.Translate(movement);

        // Rotate the avatar
        float rotationAmount = _direction.x * _rotationSpeed * Time.fixedDeltaTime;
        transform.Rotate(Vector3.up, rotationAmount);
    }
}