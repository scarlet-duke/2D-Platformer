using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private int _purse;
    [SerializeField] Health health;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin coin))
        {
            coin.Disappear();
            _purse++;
        }
        else if(other.TryGetComponent(out MedKit medKit))
        {
            health.HealingDamage(medKit.Healing);
            medKit.Disappear();
        }
    }
}
