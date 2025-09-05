using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsFinder : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypointIndex = 0;
}
