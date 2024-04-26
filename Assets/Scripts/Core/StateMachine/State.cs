namespace PufferSoftware.Scripts.Core.StateMachine
{
    public abstract class State
    {
        #region Abstract Methods

        public abstract void OnEnter();
        public abstract void OnUpdate(float deltaTime);
        public abstract void OnFixedUpdate(float fixedDeltaTime);
        public abstract void OnExit();

        #endregion
    }
}