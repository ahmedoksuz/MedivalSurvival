using PufferSoftware.Scribtables;
using UnityEngine;
using UnityEngine.AI;
using PufferSoftware.Scripts.Core.StateMachine;
using PufferSoftware.Scripts.GlobalVariables;

namespace PufferSoftware.Scripts.Player.StateMachine
{
    public class PlayerBaseState : State
    {
        protected PlayerStateMachine stateMachine;
        protected PlayerInputController inputController;
        protected Rigidbody rb;
        protected Transform model;
        protected NavMeshAgent navMeshAgent;
        protected PlayerMovementScriptable playerMovementScriptable;
        protected PlayerAnimatorController playerAnimatorController;
        private Animator animator;
        private float currentSpeed = 0;

        public PlayerBaseState(PlayerStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            rb = this.stateMachine.playerRigidBody;
            inputController = this.stateMachine.inputController;
            model = this.stateMachine.model;
            navMeshAgent = this.stateMachine.playerNavMeshAgent;
            playerMovementScriptable = this.stateMachine.playerMovementScriptable;
            playerAnimatorController = this.stateMachine.playerAnimatorController;
            navMeshAgent.speed = 1;
            navMeshAgent.angularSpeed = 0;
        }

        public override void OnEnter()
        {
            navMeshAgent.enabled = true;
        }

        public override void OnUpdate(float deltaTime)
        {
            LookDirection(deltaTime);
            Move(deltaTime);
        }

        public override void OnFixedUpdate(float fixedDeltaTime)
        {
        }

        public override void OnExit()
        {
            navMeshAgent.enabled = false;
        }

        protected void Move(float deltaTime)
        {
            Vector2 inputVector = inputController.GetMovementInput();
            Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y).normalized;
            Vector3 targetPosition = rb.position + moveDirection * (playerMovementScriptable.speed * deltaTime);

            playerAnimatorController.SetAnimation(AnimationType.Walk);

            if (inputVector != Vector2.zero)
            {
                currentSpeed = Mathf.Lerp(currentSpeed, playerMovementScriptable.speed,
                    playerMovementScriptable.smooth * deltaTime);

                navMeshAgent.speed = currentSpeed;
            }
            else
            {
                navMeshAgent.speed = Mathf.Lerp(navMeshAgent.speed, playerMovementScriptable.speed,
                    playerMovementScriptable.smooth * deltaTime);
                currentSpeed = 0;
            }

            navMeshAgent.SetDestination(targetPosition);
        }

        protected void LookDirection(float deltaTime)
        {
            Vector2 inputVector = inputController.GetMovementInput();
            if (inputVector != Vector2.zero)
            {
                Vector3 direction = new Vector3(inputVector.x, 0, inputVector.y);
                Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);

                float angle = Quaternion.Angle(model.rotation, targetRotation);
                float baseTurnSpeed = playerMovementScriptable.turnSpeed * 10;
                float angleFactor = Mathf.Clamp(angle / 180f, 0.1f, 1f);
                float turnSpeed = baseTurnSpeed * angleFactor;

                model.rotation = Quaternion.RotateTowards(model.rotation, targetRotation, turnSpeed * deltaTime);
            }
        }
    }
}