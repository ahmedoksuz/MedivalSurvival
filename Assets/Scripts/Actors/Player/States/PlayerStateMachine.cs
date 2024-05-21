using System.Diagnostics.Tracing;
using PufferSoftware.Scribtables;
using PufferSoftware.Scripts.Core.StateMachine;
using PufferSoftware.Scripts.EventSystem;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using UnityEngine.InputSystem;

namespace PufferSoftware.Scripts.Player.StateMachine
{
    public class PlayerStateMachine : StateMachineBase
    {
        [HideInInspector] public Rigidbody playerRigidBody;

        [SerializeField] private LayerMask groundLayer;
        public Transform model;
        public PlayerMovementScriptable playerMovementScriptable;
        [HideInInspector] public NavMeshAgent playerNavMeshAgent;
        [HideInInspector] public PlayerInputController inputController;
        [HideInInspector] public Animator animator;
        [HideInInspector] public PlayerAnimatorController playerAnimatorController;
        public GameObject aimObject;

        private void Awake()
        {
            playerRigidBody = GetComponent<Rigidbody>();
            playerNavMeshAgent = GetComponent<NavMeshAgent>();
            inputController = GetComponent<PlayerInputController>();
            playerAnimatorController = GetComponent<PlayerAnimatorController>();
            animator = GetComponent<Animator>();
        }

        protected override void Listen(bool status)
        {
            if (status)
            {
                Register(CustomEvents.OnGameStart, OnGameStart);
                Register(CustomEvents.EnableShotgun, EnableShootGun);
                Register(CustomEvents.DisableShotGun, DisableShotGun);
            }
            else
            {
                Unregister(CustomEvents.OnGameStart, OnGameStart);
                Unregister(CustomEvents.EnableShotgun, EnableShootGun);
                Unregister(CustomEvents.DisableShotGun, DisableShotGun);
            }
        }

        private void DisableShotGun(object[] arguments)
        {
            aimObject.SetActive(false);
            SwitchState(new PlayerMoveState(this));
        }

        private void EnableShootGun(object[] arguments)
        {
            SwitchState(new PlayerShotGun(this));
        }

        private void OnGameStart(object[] arguments)
        {
            SwitchState(new PlayerMoveState(this));
        }
    }
}