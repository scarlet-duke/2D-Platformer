using System;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public event Action gameOver;

    public void Death()
    {
        gameOver?.Invoke();
    }
}
