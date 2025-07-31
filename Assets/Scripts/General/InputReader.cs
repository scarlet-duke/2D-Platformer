using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string HorizontalMovement = "Horizontal";

    public event Action Jump;
    public event Action<float> Run;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump?.Invoke();
        }

        Run?.Invoke(Input.GetAxisRaw(HorizontalMovement));
    }
}
