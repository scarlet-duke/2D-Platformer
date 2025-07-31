using UnityEngine;

public class Fliper : MonoBehaviour
{
    private float _right = 0;
    private float _left = 180;

    public void DetermineDirection(float position, float targetPosition)
    {
        if (position > targetPosition)
        {
            Flip(_left);
        }
        else if (position < targetPosition)
        {
            Flip(_right);
        }
        else
        {
            return;
        }
    }

    private void Flip(float direction)
    {
        transform.rotation = Quaternion.Euler(0, direction, 0);
    }
}
