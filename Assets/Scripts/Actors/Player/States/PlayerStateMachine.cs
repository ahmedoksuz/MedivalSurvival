using PufferSoftware.Scribtables;
using PufferSoftware.Scripts.Core.StateMachine;
using PufferSoftware.Scripts.EventSystem;
using UnityEngine;
using UnityEngine.AI;


namespace PufferSoftware.Scripts.Player.StateMachine
{
    public class PlayerStateMachine : StateMachineBase
    {
        //Genel İhtiyaçlar saklanır ve methot kayıdı yapılır

        [HideInInspector] public Rigidbody playerRigidBody;

        [SerializeField] private LayerMask groundLayer;
        public Transform model;
        public PlayerMovementScriptable playerMovementScriptable;
        [HideInInspector] public NavMeshAgent navMeshAgent;
        [HideInInspector] public PlayerInputController inputController;
        [HideInInspector] public PlayerAnimatorController playerAnimatorController;

        private void Awake()
        {
            playerRigidBody = GetComponent<Rigidbody>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            inputController = GetComponent<PlayerInputController>();
            playerAnimatorController = GetComponent<PlayerAnimatorController>();
        }

        protected override void Listen(bool status)
        {
            if (status)
                Register(CustomEvents.OnGameStart, OnGameStart);
            else
                Unregister(CustomEvents.OnGameStart, OnGameStart);
        }


        private void OnGameStart(object[] arguments)
        {
            SwitchState(new PlayerMoveState(this));
        }
    }
}