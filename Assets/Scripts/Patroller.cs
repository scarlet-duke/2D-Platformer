using TMPro;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 1.0f;

    private int _currentWaypointIndex = 0;
    private float _triggerDistance = 0.1f;

    private void Update()
    {
        if (_waypoints.Length == 0)
        {
            return;
        }

        Vector2 target = _waypoints[_currentWaypointIndex].position;
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        if (Vector2.SqrMagnitude((Vector2)transform.position - target) < _triggerDistance * _triggerDistance)
        {
            _currentWaypointIndex = ++_currentWaypointIndex % _waypoints.Length;
        }
    }
}