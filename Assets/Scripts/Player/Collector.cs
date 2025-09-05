using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private int _purse;
    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            coin.Disappear();
            _purse++;
        }
        else if(other.TryGetComponent(out MedKit medKit))
        {
            _health.Heal(medKit.Healing);
            medKit.Disappear();
        }
    }
}
