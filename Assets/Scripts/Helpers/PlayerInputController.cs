using PufferSoftware.EventSystem;
using UnityEngine.InputSystem;
using UnityEngine;

namespace PufferSoftware.Scripts.Player
{
    public class PlayerInputController : Actor
    {
        [SerializeField] private InputActionAsset playerBaseInputs;
        private InputAction moveAction;

        protected override void OnEnable()
        {
            base.OnEnable();
            moveAction = playerBaseInputs.FindAction("MovmentAction");
            moveAction.Enable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            moveAction.Disable();
        }

        public Vector2 GetMovementInput()
        {
            return moveAction.ReadValue<Vector2>();
        }
    }
}