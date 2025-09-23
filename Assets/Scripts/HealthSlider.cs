using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] protected Slider _slider;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.ValueChanged += HealthChange;
    }

    private void OnDisable()
    {
        _health.ValueChanged -= HealthChange;
    }

    private void Start()
    {
        _slider.maxValue = _health.MaxValue;
        _slider.value = _health.MaxValue;
    }

    public virtual void HealthChange(float health)
    {
        _slider.value = health;
    }
}