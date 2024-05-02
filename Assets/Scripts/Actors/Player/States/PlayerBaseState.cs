using System.Collections;
using System.Collections.Generic;
using PufferSoftware.Scripts.Core.StateMachine;
using PufferSoftware.Scripts.Player.StateMachine;
using UnityEngine;
using UnityEngine.AI;

public class PlayerBaseState : State
{
    //Player State Machineden ihtiyacı olanları alır ve Move işlemini yapar 

    protected PlayerStateMachine stateMachine;
    protected NavMeshAgent navMeshAgent;
    protected Rigidbody rb;

    protected PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        rb = this.stateMachine.playerRigidBody;
        navMeshAgent = this.stateMachine.navMeshAgent;
    }

    public override void OnEnter()
    {
    }

    public override void OnUpdate(float deltaTime)
    {
    }

    public override void OnFixedUpdate(float fixedDeltaTime)
    {
    }

    public override void OnExit()
    {
    }

    protected void Move()
    {
    }
}