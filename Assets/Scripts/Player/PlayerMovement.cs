using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _rotationSpeed = 0.4f;
    [SerializeField] private float _roadFriction = 0.4f;
    [SerializeField] private float _speedRate;
    [SerializeField] private float _sandFriction = 0.8f;
    [SerializeField] private LayerMask _roadMask;
    [SerializeField] private LayerMask _sandMask;

    private Rigidbody2D _rigidbody;
    private InputSystem_Actions _actions;
    private float _speedOffset = 0.5f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _actions = new InputSystem_Actions();
        _actions.Enable();
        _rigidbody.linearDamping = _roadFriction;
    }

    private void OnDisable()
    {
        _actions.Disable();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var input = _actions.Player.Move.ReadValue<Vector2>();
        _rigidbody.linearVelocity = Vector2.Lerp(_rigidbody.linearVelocity, transform.up * input.y * _speed, Time.fixedDeltaTime * _speedRate);

        _rigidbody.angularVelocity = _rigidbody.linearVelocity.magnitude > _speedOffset  ? - input.x * _rotationSpeed : 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & _sandMask) != 0)
        {
            _rigidbody.linearDamping = _sandFriction;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((1 << collision.gameObject.layer & _sandMask) != 0)
        {
            _rigidbody.linearDamping = _roadFriction;
        }
    }
}
