using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    private const string HorizontalMovement = "Horizontal";

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _checkRadius = 0.2f;
    [SerializeField] private CharacterAnimator _characterAnimator;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Fliper _fliper;

    private bool _isGrounded;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _inputReader.Jump += Jump;
        _inputReader.Run += Run;
    }

    private void OnDisable()
    {
        _inputReader.Jump -= Jump;
        _inputReader.Run += Run;
    }

    public void Jump()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _groundLayer);

        if (_isGrounded)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }

    public void Run(float _moveInput)
    {
        _rigidbody.velocity = new Vector2(_moveInput * _moveSpeed, _rigidbody.velocity.y);

        if (_moveInput == 0)
        {
            _characterAnimator.RunAnimation(false);
        }
        else
        {
            _fliper.DetermineDirection(_rigidbody.position.x, _rigidbody.position.x + _moveInput);
            _characterAnimator.RunAnimation(true);
        }
    }
}
