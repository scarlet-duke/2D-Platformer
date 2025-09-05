using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void RunAnimation(bool isRunning)
    {
        _animator.SetBool(AnimatorConstans.RunningHash, isRunning);
    }
}
