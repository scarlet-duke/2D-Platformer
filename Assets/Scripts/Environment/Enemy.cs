using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private LifePlayer _lifePlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<LifePlayer>(out _))
        {
            _lifePlayer.Death();
        }
    }
}
