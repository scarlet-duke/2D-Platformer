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
    [SerializeField] private LayerMask _layerMask;

    private Coroutine _durationCoroutine;
    private Coroutine _reloadingCoroutine;
    private bool isActive = false;
    private WaitForSeconds _waitForSeconds;
    private Collider2D[] hitColliders;

    public event Action<float, float> ValueChanged;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_reloading);
        hitColliders = new Collider2D[5];
    }

    public void ClickVampirismAbilityButton()
    {
        if (isActive == false)
        {
            isActive = true;
            ValueChanged?.Invoke(0, _duration);
            _durationCoroutine = StartCoroutine(RunDurationCoroutine());
        }
    }

    private IEnumerator RunDurationCoroutine() 
    {
        Health health;
        float counter = 0;

        while (counter < _duration) 
        {
            counter += Time.deltaTime;
            yield return null;
            health = GetClosesEnemy();

            if (health != null)
            {
                health.TakeDamage(_value * Time.deltaTime);
                _healyhPlayer.Heal(_value * Time.deltaTime);
            }
        }

        ValueChanged?.Invoke(1, _reloading);
        _reloadingCoroutine = StartCoroutine(ReloadingCoroutine());
    }

    private IEnumerator ReloadingCoroutine()
    {
        yield return _waitForSeconds;
        isActive = false;
    }

    private Health GetClosesEnemy()
    {
        Health closesHealth = null;
        float closesDistance = float.MaxValue;

        int amount = Physics2D.OverlapCircleNonAlloc(transform.position, _circleCollider.radius, hitColliders, _layerMask);

        for (int i = 0; i < amount; i++)
        {
            if (hitColliders[i].TryGetComponent(out Health health))
            {
                Vector3 direction = transform.position - health.transform.position;
                if (direction.magnitude < closesDistance)
                {
                    closesDistance = direction.magnitude;
                    closesHealth = health;
                }
            }
        }

        return closesHealth;
    }
}