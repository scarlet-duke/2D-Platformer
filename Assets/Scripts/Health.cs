using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxValue = 100;
    [SerializeField] private float _value;
    [SerializeField] private GameObject _gameObject;

    private bool _canTakeDamage = true;
    private float _invincibilityFrames = 1f;
    private WaitForSeconds _waitForSeconds;

    public event Action GameOver;
    public event Action<float> ValueChanged;

    public float MaxValue => _maxValue;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_invincibilityFrames);
    }

    private void Start()
    {
        _value = MaxValue;
    }

    private void Death()
    {
        GameOver?.Invoke();
        Destroy(_gameObject);
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            return;
        }

        if (_canTakeDamage)
        {
            _value -= damage;

            if (_value <= 0)
            {
                _value = 0;
                Death();
            }

            ValueChanged?.Invoke(_value);
        }
    }

    public void Heal(float healing)
    {
        if (healing < 0)
        {
            return;
        }

        _value += healing;

        if (_value > MaxValue)
        {
            _value = MaxValue;
        }

        ValueChanged?.Invoke(_value);
    }
}
