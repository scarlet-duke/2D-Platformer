using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : MonoBehaviour
{
    [SerializeField] private int _healing = 25;

    public int Healing => _healing;

    public void Disappear()
    {
        Destroy(gameObject);
    }
}
