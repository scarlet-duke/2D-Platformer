using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private float _healing = 25;

    public float Healing => _healing;

    public void Disappear()
    {
        Destroy(gameObject);
    }
}
