using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<LifePlayer>(out var lifePlayer))
        {
            lifePlayer.Death();
        }
    }
}
