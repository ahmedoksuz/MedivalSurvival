using System.Numerics;
using PufferSoftware.Scripts.Player.StateMachine;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace PufferSoftware.Scripts.Player.StateMachine
{
    public class PlayerMoveState : PlayerBaseState
    {
        //Base Stadeki Move u kullanr ve Genel çevre kontrollerini yapar
        public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void OnEnter()
        {
        }

        public override void OnUpdate(float deltaTime)
        {
            LookDirection(deltaTime);
        }

        public override void OnFixedUpdate(float fixedDeltaTime)
        {
            Move(fixedDeltaTime);
        }


        public override void OnExit()
        {
        }
    }
}