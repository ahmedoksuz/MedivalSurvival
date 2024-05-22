using PufferSoftware.Scripts.EventSystem;
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
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }

        public override void OnFixedUpdate(float fixedDeltaTime)
        {
            Move(fixedDeltaTime);
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
                targetPosition.y = stateMachine.transform.position.y;
                stateMachine.transform.LookAt(targetPosition);
            }
        }

        private void Shoot()
        {
            Debug.Log("Hedefe ateş ediliyor");
        }
    }
}