using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private HealthPlayer _healthPlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<HealthPlayer>(out _))
        {
            _healthPlayer.Death();
        }
    }
}
