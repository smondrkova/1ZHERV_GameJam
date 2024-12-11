//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input/PlayerInput.inputactions
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

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""PlayerControl"",
            ""id"": ""0631d918-a548-4a2c-9138-376f19a9108c"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""2e135e29-6a80-4729-b846-cce23c4a7fba"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""ebe24fe5-a6bd-4e7a-9683-df149d9eeaa9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Value"",
                    ""id"": ""43ad74c3-9c63-4a1a-8e95-f7ce2abe10f2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""PassThrough"",
                    ""id"": ""0a2b5129-ff90-4b10-a076-375e80820f99"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""PassThrough"",
                    ""id"": ""df2b641a-c42f-4fcc-b243-b83cf237cc90"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CharacterSelect"",
                    ""type"": ""Button"",
                    ""id"": ""bd61615f-1932-479b-8f9b-719a232bb34c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PickUpPlace"",
                    ""type"": ""Button"",
                    ""id"": ""234035e6-c730-4259-9bbd-a9d1d7eaa3b5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""54dffd4d-2345-4f02-a8b7-af543a17c469"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c53c9a6f-b68b-40a7-950a-2b80b2cee76c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse;M&K"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""f9a4f25f-eb4e-4849-8fce-050299097ce1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse;M&K"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""dd566ac8-49d2-46a7-b42a-cfe02db71071"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse;M&K"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""940db35c-16e5-4124-a9e0-11be4f49df4d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse;M&K"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a30837df-8e06-492a-b136-0b8aa6c66ccd"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse;M&K"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2a89e4b9-f057-43f1-ba74-30ce70a455c3"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse;M&K"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""64983061-1bda-4e4a-8591-bb62f8a518d5"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse;M&K"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""23cf365b-17f2-4c93-a3cd-8f94c655b405"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse;M&K"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""55c96213-1dec-453b-b8b6-390f5d10e646"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac75e622-8b92-4e75-9e32-a683e34e5234"",
                    ""path"": ""<Pointer>/delta"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false),ScaleVector2(x=15,y=15)"",
                    ""groups"": ""KeyboardMouse;M&K"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4fc17e44-3c29-473a-b887-021bd2d3fa1a"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertX=false),StickDeadzone,ScaleVector2(x=300,y=300)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5396b8a3-af2f-45f2-b576-5dec29cea5e2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse;M&K"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a68b8687-557b-481b-9bc4-43d0f645fab2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8563376b-009e-4eba-b18f-9c63ecb40bbf"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardMouse;M&K"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""273f5b88-4bd5-48f5-b3c5-3a11b3a23098"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08ea6035-1855-451c-9ee6-445dbe693610"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""M&K"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc9d721f-4b56-469a-8abc-4ded8f0c7d30"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a1a849e-fa2c-43db-9507-8987bed90bb0"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": ""Scale"",
                    ""groups"": ""M&K"",
                    ""action"": ""CharacterSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4af0c8ef-2b15-4561-9b86-2e07d439f0d2"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": ""Scale"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CharacterSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""13f1e188-5c11-4909-b6f6-e1b1900abd03"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": ""M&K"",
                    ""action"": ""CharacterSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""76d573df-e17e-41a4-bd65-e136a59975ef"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=2)"",
                    ""groups"": """",
                    ""action"": ""CharacterSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08aaa86f-78e1-4e2b-9235-45d9410ee680"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=3)"",
                    ""groups"": ""M&K"",
                    ""action"": ""CharacterSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1e1eab14-0d42-4735-9f76-62e87b63266b"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=3)"",
                    ""groups"": ""Gamepad"",
                    ""action"": ""CharacterSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b5637026-4f08-4ecb-8ec9-d2b2f811af54"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=4)"",
                    ""groups"": ""M&K"",
                    ""action"": ""CharacterSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""42900391-8ac0-4625-9016-7352ef2c9b9d"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=4)"",
                    ""groups"": """",
                    ""action"": ""CharacterSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""caea1e63-3658-46fe-a252-2f4c7e3ad687"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=5)"",
                    ""groups"": """",
                    ""action"": ""CharacterSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b1ade6a-c8aa-4302-bffb-cfc87954ab96"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=5)"",
                    ""groups"": """",
                    ""action"": ""CharacterSelect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""65e0d819-eb6e-4aed-9b05-42b7387bedfe"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""M&K"",
                    ""action"": ""PickUpPlace"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""M&K"",
            ""bindingGroup"": ""M&K"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // PlayerControl
        m_PlayerControl = asset.FindActionMap("PlayerControl", throwIfNotFound: true);
        m_PlayerControl_Move = m_PlayerControl.FindAction("Move", throwIfNotFound: true);
        m_PlayerControl_Look = m_PlayerControl.FindAction("Look", throwIfNotFound: true);
        m_PlayerControl_Jump = m_PlayerControl.FindAction("Jump", throwIfNotFound: true);
        m_PlayerControl_Sprint = m_PlayerControl.FindAction("Sprint", throwIfNotFound: true);
        m_PlayerControl_Crouch = m_PlayerControl.FindAction("Crouch", throwIfNotFound: true);
        m_PlayerControl_CharacterSelect = m_PlayerControl.FindAction("CharacterSelect", throwIfNotFound: true);
        m_PlayerControl_PickUpPlace = m_PlayerControl.FindAction("PickUpPlace", throwIfNotFound: true);
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

    // PlayerControl
    private readonly InputActionMap m_PlayerControl;
    private List<IPlayerControlActions> m_PlayerControlActionsCallbackInterfaces = new List<IPlayerControlActions>();
    private readonly InputAction m_PlayerControl_Move;
    private readonly InputAction m_PlayerControl_Look;
    private readonly InputAction m_PlayerControl_Jump;
    private readonly InputAction m_PlayerControl_Sprint;
    private readonly InputAction m_PlayerControl_Crouch;
    private readonly InputAction m_PlayerControl_CharacterSelect;
    private readonly InputAction m_PlayerControl_PickUpPlace;
    public struct PlayerControlActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerControlActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerControl_Move;
        public InputAction @Look => m_Wrapper.m_PlayerControl_Look;
        public InputAction @Jump => m_Wrapper.m_PlayerControl_Jump;
        public InputAction @Sprint => m_Wrapper.m_PlayerControl_Sprint;
        public InputAction @Crouch => m_Wrapper.m_PlayerControl_Crouch;
        public InputAction @CharacterSelect => m_Wrapper.m_PlayerControl_CharacterSelect;
        public InputAction @PickUpPlace => m_Wrapper.m_PlayerControl_PickUpPlace;
        public InputActionMap Get() { return m_Wrapper.m_PlayerControl; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControlActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerControlActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerControlActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerControlActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Sprint.started += instance.OnSprint;
            @Sprint.performed += instance.OnSprint;
            @Sprint.canceled += instance.OnSprint;
            @Crouch.started += instance.OnCrouch;
            @Crouch.performed += instance.OnCrouch;
            @Crouch.canceled += instance.OnCrouch;
            @CharacterSelect.started += instance.OnCharacterSelect;
            @CharacterSelect.performed += instance.OnCharacterSelect;
            @CharacterSelect.canceled += instance.OnCharacterSelect;
            @PickUpPlace.started += instance.OnPickUpPlace;
            @PickUpPlace.performed += instance.OnPickUpPlace;
            @PickUpPlace.canceled += instance.OnPickUpPlace;
        }

        private void UnregisterCallbacks(IPlayerControlActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Sprint.started -= instance.OnSprint;
            @Sprint.performed -= instance.OnSprint;
            @Sprint.canceled -= instance.OnSprint;
            @Crouch.started -= instance.OnCrouch;
            @Crouch.performed -= instance.OnCrouch;
            @Crouch.canceled -= instance.OnCrouch;
            @CharacterSelect.started -= instance.OnCharacterSelect;
            @CharacterSelect.performed -= instance.OnCharacterSelect;
            @CharacterSelect.canceled -= instance.OnCharacterSelect;
            @PickUpPlace.started -= instance.OnPickUpPlace;
            @PickUpPlace.performed -= instance.OnPickUpPlace;
            @PickUpPlace.canceled -= instance.OnPickUpPlace;
        }

        public void RemoveCallbacks(IPlayerControlActions instance)
        {
            if (m_Wrapper.m_PlayerControlActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerControlActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerControlActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerControlActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerControlActions @PlayerControl => new PlayerControlActions(this);
    private int m_MKSchemeIndex = -1;
    public InputControlScheme MKScheme
    {
        get
        {
            if (m_MKSchemeIndex == -1) m_MKSchemeIndex = asset.FindControlSchemeIndex("M&K");
            return asset.controlSchemes[m_MKSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerControlActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnCharacterSelect(InputAction.CallbackContext context);
        void OnPickUpPlace(InputAction.CallbackContext context);
    }
}
