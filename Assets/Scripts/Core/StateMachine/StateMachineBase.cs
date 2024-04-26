using PufferSoftware.EventSystem;
using UnityEngine;

namespace PufferSoftware.Scripts.Core.StateMachine
{
    public class StateMachineBase : Actor
    {

        private State _currentState;
        
        private void Update()
        {
            _currentState?.OnUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _currentState?.OnFixedUpdate(Time.fixedDeltaTime);
        }
        
        public void SwitchState(State newState)
        {
            _currentState?.OnExit();
            _currentState = newState;
            _currentState.OnEnter();
        }

     
    }
}