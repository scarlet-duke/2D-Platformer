using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private float _checkRadius = 0.2f;

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _groundLayer);
    }
}
