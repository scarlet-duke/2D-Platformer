using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HealthSmoothSlider : HealthSlider
{
    private float _delayHealthChange = 0.01f;
    private float _maxDelta = 1;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_delayHealthChange);
    }

    public override void HealthChange(float health)
    {
        StartCoroutine(DelaySliderMovement(health));
    }

    private IEnumerator DelaySliderMovement(float health)
    {
        while (_slider.value != health)
        {
            yield return _waitForSeconds;
            _slider.value = Mathf.MoveTowards(_slider.value, health, _maxDelta);
        }
    }
}