using System;
using PufferSoftware.EventSystem;
using PufferSoftware.Manager;
using PufferSoftware.Scripts.GlobalVariables;
using UnityEngine;

public class PlayerAnimatorController : Actor
{
    private Animator animator;
    [HideInInspector] public AnimationType animationType;

    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int BaseAtack = Animator.StringToHash("BaseAtack");
    private static readonly int SpecialAtack = Animator.StringToHash("SpecialAtack");
    private static readonly int Die = Animator.StringToHash("Die");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAnimation(AnimationType _animationType)
    {
        if (_animationType != animationType)
        {
            animationType = _animationType;
            switch (animationType)
            {
                case AnimationType.Idle:
                    animator.SetTrigger(Idle);
                    break;
                case AnimationType.Walk:
                    animator.SetTrigger(Walk);
                    break;
                case AnimationType.BaseAtack:
                    animator.SetTrigger(BaseAtack);
                    break;
                case AnimationType.SpecialAtack:
                    animator.SetTrigger(SpecialAtack);
                    break;
                case AnimationType.Die:
                    animator.SetTrigger(Die);
                    break;
            }
        }
    }
}