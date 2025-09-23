using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private float _value = 5;
    [SerializeField] private Health _healyhPlayer;
    [SerializeField] private CircleCollider2D _circleCollider;
    [SerializeField] private float _duration = 6f;
    [SerializeField] private float _reloading = 4f;
    [SerializeField] private VampirismSlider _vampirismSlider;

    private Coroutine _durationCoroutine;
    private Coroutine _reloadingCoroutine;
    bool isActive = false;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_reloading);
    }

    public void VampirismAbilityButtonClik()
    {
        if (isActive == false)
        {
            isActive = true;
            _vampirismSlider.VampirismChange(0, _duration);
            _durationCoroutine = StartCoroutine(DurationCoroutine());
        }
    }

    private IEnumerator DurationCoroutine() 
    {
        Enemy enemy;
        float counter = 0;

        while (counter < _duration) 
        {
            counter += Time.deltaTime;
            yield return null;
            enemy = GetClosesEnemy();

            if (enemy != null)
            {
                enemy.TakeDamage(_value * Time.deltaTime);
                _healyhPlayer.Heal(_value * Time.deltaTime);
            }
        }

        _vampirismSlider.VampirismChange(1, _reloading);
        _reloadingCoroutine = StartCoroutine(ReloadingCoroutine());
    }

    private IEnumerator ReloadingCoroutine()
    {
        yield return _waitForSeconds;
        isActive = false;
    }

    private Enemy GetClosesEnemy()
    {
        Enemy closesEnemy = null;
        float closesDistance = float.MaxValue;

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _circleCollider.radius);

        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out Enemy enemy))
            {
                Vector3 direction = transform.position - enemy.transform.position;
                if (direction.magnitude < closesDistance)
                {
                    closesDistance = direction.magnitude;
                    closesEnemy = enemy;
                }
            }
        }

        return closesEnemy;
    }
}