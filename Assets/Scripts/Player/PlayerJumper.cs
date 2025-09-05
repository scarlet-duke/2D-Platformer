using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerJumper : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private GroundDetector _groundDetector;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (_groundDetector.IsGrounded())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }
}
