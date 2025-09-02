using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTouch : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out var health))
        {
            health.TakeDamage(_damage);
        }
    }
}
