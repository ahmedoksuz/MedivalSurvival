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

        public PlayerBaseState(PlayerStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            rb = this.stateMachine.playerRigidBody;
            inputController = this.stateMachine.inputController;
            model = this.stateMachine.model;
            navMeshAgent = this.stateMachine.navMeshAgent;
            playerMovementScriptable = this.stateMachine.playerMovementScriptable;
            playerAnimatorController = this.stateMachine.playerAnimatorController;
            navMeshAgent.speed = playerMovementScriptable.speed;
            navMeshAgent.angularSpeed = 0;
        }

        public override void OnEnter()
        {
            navMeshAgent.enabled = true;
        }

        public override void OnUpdate(float deltaTime)
        {
            Move(deltaTime);
            LookDirection(deltaTime);
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
            Vector3 targetPosition = rb.position + moveDirection * (playerMovementScriptable.speed * deltaTime * 10);
            if (moveDirection != Vector3.zero)
            {
                playerAnimatorController.SetAnimation(AnimationType.Walk);
                navMeshAgent.SetDestination(targetPosition);
            }
            else
            {
                playerAnimatorController.SetAnimation(AnimationType.Idle);
            }
        }

        protected void LookDirection(float deltaTime)
        {
            if (navMeshAgent.velocity.sqrMagnitude > Mathf.Epsilon)
            {
                Vector3 velocityDirection = new Vector3(navMeshAgent.velocity.x, 0, navMeshAgent.velocity.z).normalized;
                Quaternion targetRotation = Quaternion.LookRotation(velocityDirection);
                if (Quaternion.Angle(model.rotation, targetRotation) > 1f)
                    model.rotation = Quaternion.Slerp(model.rotation, targetRotation,
                        playerMovementScriptable.turnSpeed * deltaTime);
            }
        }
    }
}