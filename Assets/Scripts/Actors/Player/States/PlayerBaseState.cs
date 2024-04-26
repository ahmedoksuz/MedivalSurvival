using PufferSoftware.Scribtables;
using PufferSoftware.Scripts.Core.StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace PufferSoftware.Scripts.Player.StateMachine
{
    public abstract class PlayerBaseState : State
    {
        
        protected Rigidbody rigidBody;
        protected Transform weaponTransform;
        protected UnityEngine.Camera mainCamera;
        protected NavMeshAgent navMeshAgent;


        protected PlayerMovmentScribtable playerMovmentScribtable;

        protected Vector3 input;

  
   
    }
}