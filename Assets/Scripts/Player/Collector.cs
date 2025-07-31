using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private int _purse;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Coin resource))
        {
            resource.Disappear();
            _purse++;
        }
    }
}
