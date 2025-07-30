using System;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public event Action GameOver;

    public void Death()
    {
        GameOver?.Invoke();
    }
}
