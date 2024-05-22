using PufferSoftware.EventSystem;
using PufferSoftware.Scripts.EventSystem;
using UnityEngine.InputSystem;
using UnityEngine;

namespace PufferSoftware.Scripts.Player
{
    public class PlayerInputController : Actor
    {
        [SerializeField] private InputActionAsset playerBaseInputs;
        private PlayerBaseImputs _playerInputActions;
        public Vector2 moveVector;

        protected void Awake()
        {
            _playerInputActions = new PlayerBaseImputs();
            _playerInputActions.Player.MovementAction.performed += Move;
            _playerInputActions.Player.AimAction.performed += ShotgunPerformed;
            _playerInputActions.Player.MovementAction.canceled += Move;
            _playerInputActions.Player.Click.performed += DisableShootGun;
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _playerInputActions.Enable();
        }

        protected override void OnDisable()
        {
            base.OnDisable();


            _playerInputActions.Disable();
        }

        private void Move(InputAction.CallbackContext context)
        {
            moveVector = context.phase switch
            {
                InputActionPhase.Performed => context.ReadValue<Vector2>(),
                InputActionPhase.Canceled => Vector2.zero, _ => moveVector
            };
        }

        private void ShotgunPerformed(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Push(CustomEvents.EnableShotgun);
            }
        }

        private void DisableShootGun(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Push(CustomEvents.DisableShotGun);
            }
        }
    }
}