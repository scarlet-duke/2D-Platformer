using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDetector : MonoBehaviour
{
    [SerializeField] private Patroller _patroller;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMover>(out var playerMover))
        {
            _patroller.ChangeTarget(playerMover.transform);
        }
    }
}
