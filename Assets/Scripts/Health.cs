using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _health;

    public event Action GameOver;
    private bool _canTakeDamage = true;
    private float _invincibilityFrames = 1f;

    private void Start()
    {
        _health = _maxHealth;
    }

    private void Death()
    {
        GameOver?.Invoke();
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            return;
        }

        if (_canTakeDamage)
        {
            _health -= damage;

            if (_health <= 0)
            {
                Death();
            }

            _canTakeDamage = false;
            StartCoroutine(DelayBeforeTakingDamage());
        }
    }

    public void Heal(int healing)
    {
        if (healing < 0)
        {
            return;
        }

        _health += healing;

        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }
    }

    private IEnumerator DelayBeforeTakingDamage()
    {
        yield return new WaitForSeconds(_invincibilityFrames);
        _canTakeDamage = true;
    }
}
