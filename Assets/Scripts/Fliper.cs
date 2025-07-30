using UnityEngine;

public class Fliper : MonoBehaviour
{
    private float _lastPosition;
    private float _right = 0;
    private float _left = 180;

    private void FixedUpdate()
    {
        float position = transform.position.x;

        if (_lastPosition > position)
        {
            Flip(_left);
        }
        else if (_lastPosition < position)
        {
            Flip(_right);
        }
        else
        {
            return;
        }

        _lastPosition = position;
    }

    private void Flip(float direction)
    {
        transform.rotation = Quaternion.Euler(0, direction, 0);
    }
}
