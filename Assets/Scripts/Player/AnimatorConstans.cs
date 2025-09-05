using UnityEngine;

public static class AnimatorConstans
{
    public static readonly int RunningHash = Animator.StringToHash(IsRunning);
    private const string IsRunning = nameof(IsRunning);
}