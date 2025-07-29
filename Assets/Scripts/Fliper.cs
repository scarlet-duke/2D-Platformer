using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Fliper : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private float _lastPosition;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        float position = transform.position.x;

        if (_lastPosition > position)
        {
            Flip(true);
        }
        else if( _lastPosition < position)
        {
            Flip(false);
        }
        else
        {
            return;
        }

        _lastPosition = position;
    }

    private void Flip(bool isFacingRight)
    {
        _spriteRenderer.flipX = isFacingRight;
    }
}
