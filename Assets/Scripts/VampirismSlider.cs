using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class VampirismSlider : MonoBehaviour
{
    [SerializeField] protected Slider _slider;
    [SerializeField] protected Vampirism _vampirism;

    private float _maxDelta;

    private void OnEnable()
    {
        _vampirism.ValueChanged += ChangeVampirism;
    }

    private void OnDisable()
    {
        _vampirism.ValueChanged -= ChangeVampirism;
    }

    public void ChangeVampirism(float scaleChange, float durationAction)
    {
        StartCoroutine(AnimateSliderToValue(scaleChange, durationAction));
    }

    private IEnumerator AnimateSliderToValue(float scaleChange, float durationAction)
    {
        _maxDelta = Mathf.Abs(_slider.maxValue / durationAction);

        while (_slider.value != scaleChange)
        {
            yield return null;
            _slider.value = Mathf.MoveTowards(_slider.value, scaleChange, _maxDelta * Time.deltaTime);
        }
    }
}
