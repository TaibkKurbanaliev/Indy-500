using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _angularSpeed;
    [SerializeField] private float _friction = 0.4f;

    private Rigidbody2D _rigidbody;
    private InputSystem_Actions _actions;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _actions = new InputSystem_Actions();
        _actions.Enable();
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
        var input = _actions.Player.Move.ReadValue<Vector2>().y;
        Debug.Log(transform.forward * _speed);
        _rigidbody.AddForce(transform.up * _speed * input * Time.fixedDeltaTime);
        _rigidbody.linearDamping = _friction;
    }
}
