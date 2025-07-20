using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> Disappeard;

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.gameObject.TryGetComponent(out Player player))
        {
            Disappeard?.Invoke(this);
        }
    }
}
