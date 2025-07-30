using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;

    public event Action Jump;
    public event Action<float> Run;

    private const string HorizontalMovement = "Horizontal";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump?.Invoke();
        }
    }

    private void FixedUpdate()
    {
        if(Input.GetAxisRaw(HorizontalMovement) != null)
        {
            Run?.Invoke(Input.GetAxisRaw(HorizontalMovement));
        }
    }
}
