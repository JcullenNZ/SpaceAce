//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/PlayerControls.inputactions
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

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""NameEntry"",
            ""id"": ""55a689f4-d486-42a6-8c0f-e3b9249c07e2"",
            ""actions"": [
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""65a45479-22f4-4e27-a5aa-9bb6d7ec0054"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""6fae57b6-2192-4c94-a79e-53df313419d9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""71e6bf53-d2a5-48ab-a419-b1439a70d13c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8fed620d-b69a-4b13-80ae-cf3ada296de9"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""75889c76-1aaf-42ef-8da2-3094eea3953d"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57773b25-a0dd-4439-832d-17b501c536c5"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InGame"",
            ""id"": ""0787b34c-712d-4553-b0ce-a305ad907489"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""c10c4abc-8807-45e2-bc8d-f23bf6361374"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""81202a79-8107-43d8-9895-d79731415509"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""f9580a3c-0adf-4f07-98c4-10433bf97616"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""25b0c959-b6d3-4041-b29a-425b5f8b0e6a"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f9c33d64-875f-4738-97aa-ed40a97d20bf"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bac2e2f4-e92d-4d4b-8070-b8553de627df"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // NameEntry
        m_NameEntry = asset.FindActionMap("NameEntry", throwIfNotFound: true);
        m_NameEntry_Up = m_NameEntry.FindAction("Up", throwIfNotFound: true);
        m_NameEntry_Down = m_NameEntry.FindAction("Down", throwIfNotFound: true);
        m_NameEntry_Submit = m_NameEntry.FindAction("Submit", throwIfNotFound: true);
        // InGame
        m_InGame = asset.FindActionMap("InGame", throwIfNotFound: true);
        m_InGame_Shoot = m_InGame.FindAction("Shoot", throwIfNotFound: true);
        m_InGame_Move = m_InGame.FindAction("Move", throwIfNotFound: true);
        m_InGame_Pause = m_InGame.FindAction("Pause", throwIfNotFound: true);
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

    // NameEntry
    private readonly InputActionMap m_NameEntry;
    private List<INameEntryActions> m_NameEntryActionsCallbackInterfaces = new List<INameEntryActions>();
    private readonly InputAction m_NameEntry_Up;
    private readonly InputAction m_NameEntry_Down;
    private readonly InputAction m_NameEntry_Submit;
    public struct NameEntryActions
    {
        private @PlayerControls m_Wrapper;
        public NameEntryActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Up => m_Wrapper.m_NameEntry_Up;
        public InputAction @Down => m_Wrapper.m_NameEntry_Down;
        public InputAction @Submit => m_Wrapper.m_NameEntry_Submit;
        public InputActionMap Get() { return m_Wrapper.m_NameEntry; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NameEntryActions set) { return set.Get(); }
        public void AddCallbacks(INameEntryActions instance)
        {
            if (instance == null || m_Wrapper.m_NameEntryActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_NameEntryActionsCallbackInterfaces.Add(instance);
            @Up.started += instance.OnUp;
            @Up.performed += instance.OnUp;
            @Up.canceled += instance.OnUp;
            @Down.started += instance.OnDown;
            @Down.performed += instance.OnDown;
            @Down.canceled += instance.OnDown;
            @Submit.started += instance.OnSubmit;
            @Submit.performed += instance.OnSubmit;
            @Submit.canceled += instance.OnSubmit;
        }

        private void UnregisterCallbacks(INameEntryActions instance)
        {
            @Up.started -= instance.OnUp;
            @Up.performed -= instance.OnUp;
            @Up.canceled -= instance.OnUp;
            @Down.started -= instance.OnDown;
            @Down.performed -= instance.OnDown;
            @Down.canceled -= instance.OnDown;
            @Submit.started -= instance.OnSubmit;
            @Submit.performed -= instance.OnSubmit;
            @Submit.canceled -= instance.OnSubmit;
        }

        public void RemoveCallbacks(INameEntryActions instance)
        {
            if (m_Wrapper.m_NameEntryActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(INameEntryActions instance)
        {
            foreach (var item in m_Wrapper.m_NameEntryActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_NameEntryActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public NameEntryActions @NameEntry => new NameEntryActions(this);

    // InGame
    private readonly InputActionMap m_InGame;
    private List<IInGameActions> m_InGameActionsCallbackInterfaces = new List<IInGameActions>();
    private readonly InputAction m_InGame_Shoot;
    private readonly InputAction m_InGame_Move;
    private readonly InputAction m_InGame_Pause;
    public struct InGameActions
    {
        private @PlayerControls m_Wrapper;
        public InGameActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_InGame_Shoot;
        public InputAction @Move => m_Wrapper.m_InGame_Move;
        public InputAction @Pause => m_Wrapper.m_InGame_Pause;
        public InputActionMap Get() { return m_Wrapper.m_InGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void AddCallbacks(IInGameActions instance)
        {
            if (instance == null || m_Wrapper.m_InGameActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_InGameActionsCallbackInterfaces.Add(instance);
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IInGameActions instance)
        {
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IInGameActions instance)
        {
            foreach (var item in m_Wrapper.m_InGameActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_InGameActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public InGameActions @InGame => new InGameActions(this);
    public interface INameEntryActions
    {
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
    }
    public interface IInGameActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
}
