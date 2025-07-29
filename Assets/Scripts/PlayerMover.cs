using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private const string HorizontalMovement = "Horizontal";

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _checkRadius = 0.2f;
    [SerializeField] private Animator _animator;

    private bool _isGrounded;
    private Rigidbody2D _rigidbody;
    private float _moveInput;
    private int _runningHash;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _runningHash = Animator.StringToHash("IsRunning");
    }

    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }

    private void FixedUpdate()
    {
        _moveInput = Input.GetAxisRaw(HorizontalMovement);
        _rigidbody.velocity = new Vector2(_moveInput * _moveSpeed, _rigidbody.velocity.y);

        if (_moveInput == 0)
        {
            _animator.SetBool(_runningHash, false);
        }
        else
        {
            _animator.SetBool(_runningHash, true);
        }
    }
}
