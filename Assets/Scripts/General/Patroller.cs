using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Fliper _fliper;

    private int _currentWaypointIndex = 0;
    private float _triggerDistance = 0.1f;
    private bool _targetFound = false;
    private Transform _player;

    private void Update()
    {
        if (_waypoints.Length == 0)
        {
            return;
        }

        Vector2 target = _waypoints[_currentWaypointIndex].position;

        if (_targetFound)
        {
            target = _player.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        if (Vector2.SqrMagnitude((Vector2)transform.position - target) < _triggerDistance * _triggerDistance)
        {
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;
        }

        _fliper.DetermineDirection(transform.position.x, target.x);
    }

    public void ChangeTarget(Transform target)
    {
        _player = target;
        _targetFound = true;
    }
}