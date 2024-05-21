using System.Collections;
using System.Collections.Generic;
using PufferSoftware.Scripts.GlobalVariables;
using UnityEngine;

namespace PufferSoftware.Scripts.Player.StateMachine
{
    public class PlayerShotGun : PlayerBaseState
    {
        private GameObject aimObject;
        private bool isAiming;
        private Camera cam;
        private Camera _camera;

        public PlayerShotGun(PlayerStateMachine stateMachine) : base(stateMachine)
        {
            aimObject = stateMachine.aimObject;
            isAiming = false;
        }

        public override void OnEnter()
        {
            _camera = Camera.main;
            isAiming = true;
            aimObject.SetActive(isAiming);
            stateMachine.playerAnimatorController.SetAnimation(AnimationType.Aim);
            cam = _camera;
        }

        public override void OnUpdate(float deltaTime)
        {
            UpdateAimDirection();
        }

        public override void OnFixedUpdate(float fixedDeltaTime)
        {
        }

        public override void OnExit()
        {
            isAiming = false;
            aimObject.SetActive(isAiming);
        }

        private void UpdateAimDirection()
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 targetPosition = hit.point;
                targetPosition.y = stateMachine.transform.position.y; // Keep the y position same as the player
                stateMachine.transform.LookAt(targetPosition);
            }
        }
    }
}