using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _runningHash;

    private void Start()
    {
        _runningHash = Animator.StringToHash("IsRunning");
    }

    public void RunAnimation(bool isRunning)
    {
        _animator.SetBool(_runningHash, isRunning);
    }
}
