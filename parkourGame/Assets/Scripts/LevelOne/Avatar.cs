using UnityEngine;
using UnityEngine.InputSystem;

public class Avatar : MonoBehaviour
{
    [SerializeField] private float _speed = 8f;
    [SerializeField] private float _rotationSpeed = 90f; // Rotation speed in degrees per second

    private GameController _gameController;
    private bool _isPlaying;
    private Vector2 _direction;
    private Rigidbody _rigidbody;
    private PhysicMaterial _bounciness;
    private bool _toJump = false;

    public bool IsHighJumping { get; set; }
    public bool OnFloor { get; set; }

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
        _gameController.GameStatusChanged += OnGameStatusChanged;
        _rigidbody = GetComponent<Rigidbody>();
        _bounciness = GetComponent<Collider>().material;
        IsHighJumping = false;
    }

    private void OnMove(InputValue inputValue)
    {
        if (_isPlaying)
        {
            _direction = inputValue.Get<Vector2>();
        }
    }

    private void OnJump()
    {
        if (_isPlaying)
        {
            if (_toJump)
            {
                _rigidbody.AddForce(Vector3.up * 10f, ForceMode.Impulse);
                IsHighJumping = true;
                _toJump = false;
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Floor")) {
            _bounciness.bounceCombine = PhysicMaterialCombine.Maximum;
            IsHighJumping = false;
            OnFloor = true;
            _toJump = true;

        } else if (other.collider.CompareTag("Building"))
        {
            IsHighJumping = true;
            OnFloor = true;
        }
    }

    private void FixedUpdate()
    {
        
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

    private void OnGameStatusChanged(object _, GameStatus statusEnum)
    {
        _isPlaying = statusEnum == GameStatus.Playing;
    }
}