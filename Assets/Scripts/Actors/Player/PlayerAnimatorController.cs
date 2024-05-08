using System;
using PufferSoftware.EventSystem;
using PufferSoftware.Manager;
using PufferSoftware.Scribtables;
using PufferSoftware.Scripts.GlobalVariables;
using PufferSoftware.Scripts.Player.StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace PufferSoftware.Scripts.Player
{
    public class PlayerAnimatorController : Actor
    {
        [HideInInspector] public AnimationType animationType;

        private PlayerInputController inputController;
        private Animator animator;
        private PlayerStateMachine playerStateMachine;
        private NavMeshAgent playerNavMesh;
        private PlayerMovementScriptable playerMovementData;

        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int BaseAtack = Animator.StringToHash("BaseAtack");
        private static readonly int SpecialAtack = Animator.StringToHash("SpecialAtack");
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int MoveX = Animator.StringToHash("MoveX");
        private static readonly int MoveZ = Animator.StringToHash("MoveZ");
        private static readonly int AnimSpeed = Animator.StringToHash("AnimSpeed");
        private Vector2 _currentDirection;

        private void Awake()
        {
            playerStateMachine = GetComponent<PlayerStateMachine>();
            inputController = playerStateMachine.inputController;
            animator = playerStateMachine.animator;
            playerNavMesh = playerStateMachine.playerNavMeshAgent;
            playerMovementData = playerStateMachine.playerMovementScriptable;
        }

        public void SetAnimation(AnimationType _animationType)
        {
            Vector2 movementInput = inputController.GetMovementInput();


            _currentDirection.x = Mathf.Lerp(_currentDirection.x, movementInput.x, 15f * Time.deltaTime);
            _currentDirection.y = Mathf.Lerp(_currentDirection.y, movementInput.y, 15f * Time.deltaTime);

            animator.SetFloat(MoveX, _currentDirection.x);
            animator.SetFloat(MoveZ, _currentDirection.y);

            float speedRatio = playerNavMesh.speed / playerMovementData.speed;
            animator.SetFloat(AnimSpeed, speedRatio);

            if (_animationType != animationType)
            {
                animationType = _animationType;
                animator.ResetTrigger(Walk);
                animator.ResetTrigger(BaseAtack);
                animator.ResetTrigger(SpecialAtack);
                animator.ResetTrigger(Die);

                switch (animationType)
                {
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
}