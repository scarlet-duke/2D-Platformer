using System;
using UnityEngine;

public class LifePlayer : MonoBehaviour
{
    public event Action GameOver;

    public void Death()
    {
        GameOver?.Invoke();
    }
}
