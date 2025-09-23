using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class VampirismSlider : MonoBehaviour
{
    [SerializeField] protected Slider _slider;

    private float _maxDelta;

    public void VampirismChange(float scaleChange, float durationAction)
    {
        StartCoroutine(DelaySliderMovement(scaleChange, durationAction));
    }

    private IEnumerator DelaySliderMovement(float scaleChange, float durationAction)
    {
        _maxDelta = Mathf.Abs(_slider.maxValue / durationAction);

        while (_slider.value != scaleChange)
        {
            yield return null;
            _slider.value = Mathf.MoveTowards(_slider.value, scaleChange, _maxDelta * Time.deltaTime);
        }
    }
}
