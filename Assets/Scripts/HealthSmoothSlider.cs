using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HealthSmoothSlider : HealthSlider
{
    public event Action GameOver;
    private float _delayHealthChange = 0.01f;
    private int _maxDelta = 1;

    public override void HealthChange(int health)
    {
        StartCoroutine(DelaySliderMovement(health));
    }

    private IEnumerator DelaySliderMovement(int health)
    {
        while (_slider.value != health)
        {
            yield return new WaitForSeconds(_delayHealthChange);
            _slider.value = Mathf.MoveTowards(_slider.value, health, _maxDelta);
        }
    }
}