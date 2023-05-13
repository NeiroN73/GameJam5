using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimator : MonoBehaviour
{
    public Animator _animator;
    private Player _player;
    public InputSystem _inputSystem;

    public event Action OnEndAnimHammer;
    public event Action OnEndAnimCrossbow;
    public event Action OnEndAnimMop;

    private void Start()
    {
        //_cakeCatapult.OnThrowCake += OnAnimThrowCake;
        //_hammer.OnHammerAttack += OnAnimHammerAttack;

        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }

    public void OnAnimThrowCake()
    {
        _animator.SetTrigger("isCrossbowAttack");
        _inputSystem.isMoving = false;
    }

    public void OnAnimHammerAttack()
    {
        _animator.SetTrigger("isHammerAttack");
        _inputSystem.isMoving = false;
    }

    public void OnAnimMopAttack()
    {
        _animator.SetTrigger("isMopAttack");
        _inputSystem.isMoving = false;
    }

    public void EndAnimHammer() //animation event
    {
        OnEndAnimHammer?.Invoke();
        _inputSystem.isMoving = true;
    }

    public void EndAnimCrossbow() //anim event
    {
        OnEndAnimCrossbow?.Invoke();
        _inputSystem.isMoving = true;
    }

    public void EndAnimMopAttack1() //anim event
    {
        OnEndAnimMop?.Invoke();
        _inputSystem.isMoving = true;
    }

    private void Update()
    {
        AnimationMoving();
    }

    private void AnimationMoving()
    {
        Vector3 direction = _inputSystem.GetDirectionMove();
        if (direction.x == 0 && direction.z == 0)
        {
            _animator.SetBool("isMoving", false);
        }
        else
        {
            _animator.SetBool("isMoving", true);
        }
    }
}
