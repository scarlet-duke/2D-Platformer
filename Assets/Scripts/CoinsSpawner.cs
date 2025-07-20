using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _prefab;
    [SerializeField] private GameObject _startPoint;
    [SerializeField] private float _repeatRate = 0.5f;
    [SerializeField] private int _poolCapacity = 20;
    [SerializeField] private int _poolMaxSize = 40;

    private ObjectPool<Coin> _pool;
    private float _randomCoordinate = 5f;
    private float _spawnHeight = 4f;

    private void Awake()
    {
        _pool = new ObjectPool<Coin>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => ActionOnGet(obj),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false));
    }

    private void Start()
    {
        InvokeRepeating(nameof(GetCoin), 0.0f, _repeatRate);
    }

    private void ActionOnGet(Coin obj)
    {
        obj.transform.position = new Vector3(Random.Range(-_randomCoordinate, _randomCoordinate), _spawnHeight, 0);
        obj.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        obj.gameObject.SetActive(true);
        obj.Disappeard += Release;
    }

    private void GetCoin()
    {
        _pool.Get();
    }

    private void Release(Coin obj)
    {
        obj.Disappeard -= Release;
        _pool.Release(obj);
    }
}
