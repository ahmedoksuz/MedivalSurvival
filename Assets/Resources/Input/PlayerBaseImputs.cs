//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Resources/Input/PlayerBaseImputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerBaseImputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerBaseImputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerBaseImputs"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""47a462ed-7453-4083-b34c-49efac21853b"",
            ""actions"": [
                {
                    ""name"": ""MovementAction"",
                    ""type"": ""Value"",
                    ""id"": ""40e85989-cd7d-44cb-b0f8-3865f516daae"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""AimAction"",
                    ""type"": ""Button"",
                    ""id"": ""4511f8bf-c564-46f9-b648-718fed0d63bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b2949f1e-187b-4140-a8c6-ea823ab07c17"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementAction"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2a856032-877b-4535-8011-885ec4da68a8"",
                    ""path"": ""<Keyboard>/#(W)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8a1a3fe1-90dc-4737-8e7d-27c07a6b1bcb"",
                    ""path"": ""<Keyboard>/#(S)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c5633f49-9a88-4708-b034-fb3394f3ff6d"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f8beac9e-ff0e-4bfb-a8e5-c050b8c5828a"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c6625676-2297-44ee-9e73-04c37bbe3582"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AimAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MovementAction = m_Player.FindAction("MovementAction", throwIfNotFound: true);
        m_Player_AimAction = m_Player.FindAction("AimAction", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_MovementAction;
    private readonly InputAction m_Player_AimAction;
    public struct PlayerActions
    {
        private @PlayerBaseImputs m_Wrapper;
        public PlayerActions(@PlayerBaseImputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementAction => m_Wrapper.m_Player_MovementAction;
        public InputAction @AimAction => m_Wrapper.m_Player_AimAction;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @MovementAction.started += instance.OnMovementAction;
            @MovementAction.performed += instance.OnMovementAction;
            @MovementAction.canceled += instance.OnMovementAction;
            @AimAction.started += instance.OnAimAction;
            @AimAction.performed += instance.OnAimAction;
            @AimAction.canceled += instance.OnAimAction;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @MovementAction.started -= instance.OnMovementAction;
            @MovementAction.performed -= instance.OnMovementAction;
            @MovementAction.canceled -= instance.OnMovementAction;
            @AimAction.started -= instance.OnAimAction;
            @AimAction.performed -= instance.OnAimAction;
            @AimAction.canceled -= instance.OnAimAction;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovementAction(InputAction.CallbackContext context);
        void OnAimAction(InputAction.CallbackContext context);
    }
}
