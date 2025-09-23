using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Health _health;

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }
}
