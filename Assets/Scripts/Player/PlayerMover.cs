using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private CharacterAnimator _characterAnimator;
    [SerializeField] private Fliper _fliper;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Run(float moveInput)
    {
        _rigidbody.velocity = new Vector2(moveInput * _moveSpeed, _rigidbody.velocity.y);

        if (moveInput == 0)
        {
            _characterAnimator.RunAnimation(false);
        }
        else
        {
            _fliper.DetermineDirection(_rigidbody.position.x, _rigidbody.position.x + moveInput);
            _characterAnimator.RunAnimation(true);
        }
    }
}
