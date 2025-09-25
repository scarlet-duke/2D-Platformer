using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerJumper _jumper;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private Vampirism _vampirism;

    private void OnEnable()
    {
        _inputReader.Jump += Jump;
        _inputReader.Run += Run;
        _inputReader.VammpirismAbilityButtonClik += ActivateVampirism;
    }

    private void OnDisable()
    {
        _inputReader.Jump -= Jump;
        _inputReader.Run -= Run;
        _inputReader.VammpirismAbilityButtonClik -= ActivateVampirism;
    }

    private void Jump()
    {
        _jumper.Jump();
    }

    private void Run(float moveInput)
    {
        _mover.Run(moveInput);
    }

    private void ActivateVampirism()
    {
        _vampirism.ClickVampirismAbilityButton();
    }
}
