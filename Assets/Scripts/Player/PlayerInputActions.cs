// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Player
{
    public class @PlayerInputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Controls"",
            ""id"": ""30430d3b-6c3d-4a12-a563-23ee8afbac14"",
            ""actions"": [
                {
                    ""name"": ""Gas"",
                    ""type"": ""Value"",
                    ""id"": ""ff0a7968-846d-4631-8851-430657a97358"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Steering"",
                    ""type"": ""Button"",
                    ""id"": ""3c95699e-cd91-4d34-b6c5-ea962a803ad4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Handbrake"",
                    ""type"": ""Button"",
                    ""id"": ""beb8c37f-1a05-4516-995e-dc8e83dd1a41"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""cb65437c-63c4-42eb-8946-82defc8d2f26"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""W/S keyboard"",
                    ""id"": ""8aed10ed-ce25-4aae-99db-1c3d9ff80c52"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8aa6768a-08f6-4543-b95d-f19e8617a4e0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1495030d-9103-45ae-bb27-bdf74c102963"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow keyboard"",
                    ""id"": ""d987f49e-a4d9-4bac-9397-707b2e883a21"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""dbae52bf-69db-484e-96dd-1145263e1a56"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""70175a53-ae02-48bb-b3ad-0a1f3ec5479b"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Gas"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""A/D keyboard"",
                    ""id"": ""420897a2-cd80-4172-a539-36d77fa13e27"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d1eceabb-1865-48f9-8d81-d1974d085e8c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""429f4d08-2a87-495f-bfa3-29247e0ebfd9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrows keyboard"",
                    ""id"": ""92346127-8b51-4132-9e9c-b10fc82d58e3"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""dc0b07de-30bd-4268-b982-0adecf0106ab"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""1a298d60-74c6-4d26-b3c6-d8240c96c396"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steering"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""981f8b5d-e778-40b8-b24f-a2c1dde279e9"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Handbrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9506f500-0e7d-4d2a-8d00-6eae54f88402"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""UI"",
            ""id"": ""5211a48b-86c0-491a-ada4-022d4dc9a6f8"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""d07eb67b-d8e3-4265-8a93-76c6b92cbffb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6a509a41-bac1-4fad-bbb2-fe1a7098bfd3"",
                    ""path"": ""<Keyboard>/escape"",
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
            // Controls
            m_Controls = asset.FindActionMap("Controls", throwIfNotFound: true);
            m_Controls_Gas = m_Controls.FindAction("Gas", throwIfNotFound: true);
            m_Controls_Steering = m_Controls.FindAction("Steering", throwIfNotFound: true);
            m_Controls_Handbrake = m_Controls.FindAction("Handbrake", throwIfNotFound: true);
            m_Controls_Reset = m_Controls.FindAction("Reset", throwIfNotFound: true);
            // UI
            m_UI = asset.FindActionMap("UI", throwIfNotFound: true);
            m_UI_Pause = m_UI.FindAction("Pause", throwIfNotFound: true);
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

        // Controls
        private readonly InputActionMap m_Controls;
        private IControlsActions m_ControlsActionsCallbackInterface;
        private readonly InputAction m_Controls_Gas;
        private readonly InputAction m_Controls_Steering;
        private readonly InputAction m_Controls_Handbrake;
        private readonly InputAction m_Controls_Reset;
        public struct ControlsActions
        {
            private @PlayerInputActions m_Wrapper;
            public ControlsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Gas => m_Wrapper.m_Controls_Gas;
            public InputAction @Steering => m_Wrapper.m_Controls_Steering;
            public InputAction @Handbrake => m_Wrapper.m_Controls_Handbrake;
            public InputAction @Reset => m_Wrapper.m_Controls_Reset;
            public InputActionMap Get() { return m_Wrapper.m_Controls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(ControlsActions set) { return set.Get(); }
            public void SetCallbacks(IControlsActions instance)
            {
                if (m_Wrapper.m_ControlsActionsCallbackInterface != null)
                {
                    @Gas.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnGas;
                    @Gas.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnGas;
                    @Gas.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnGas;
                    @Steering.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSteering;
                    @Steering.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSteering;
                    @Steering.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnSteering;
                    @Handbrake.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnHandbrake;
                    @Handbrake.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnHandbrake;
                    @Handbrake.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnHandbrake;
                    @Reset.started -= m_Wrapper.m_ControlsActionsCallbackInterface.OnReset;
                    @Reset.performed -= m_Wrapper.m_ControlsActionsCallbackInterface.OnReset;
                    @Reset.canceled -= m_Wrapper.m_ControlsActionsCallbackInterface.OnReset;
                }
                m_Wrapper.m_ControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Gas.started += instance.OnGas;
                    @Gas.performed += instance.OnGas;
                    @Gas.canceled += instance.OnGas;
                    @Steering.started += instance.OnSteering;
                    @Steering.performed += instance.OnSteering;
                    @Steering.canceled += instance.OnSteering;
                    @Handbrake.started += instance.OnHandbrake;
                    @Handbrake.performed += instance.OnHandbrake;
                    @Handbrake.canceled += instance.OnHandbrake;
                    @Reset.started += instance.OnReset;
                    @Reset.performed += instance.OnReset;
                    @Reset.canceled += instance.OnReset;
                }
            }
        }
        public ControlsActions @Controls => new ControlsActions(this);

        // UI
        private readonly InputActionMap m_UI;
        private IUIActions m_UIActionsCallbackInterface;
        private readonly InputAction m_UI_Pause;
        public struct UIActions
        {
            private @PlayerInputActions m_Wrapper;
            public UIActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Pause => m_Wrapper.m_UI_Pause;
            public InputActionMap Get() { return m_Wrapper.m_UI; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(UIActions set) { return set.Get(); }
            public void SetCallbacks(IUIActions instance)
            {
                if (m_Wrapper.m_UIActionsCallbackInterface != null)
                {
                    @Pause.started -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                    @Pause.performed -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                    @Pause.canceled -= m_Wrapper.m_UIActionsCallbackInterface.OnPause;
                }
                m_Wrapper.m_UIActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Pause.started += instance.OnPause;
                    @Pause.performed += instance.OnPause;
                    @Pause.canceled += instance.OnPause;
                }
            }
        }
        public UIActions @UI => new UIActions(this);
        public interface IControlsActions
        {
            void OnGas(InputAction.CallbackContext context);
            void OnSteering(InputAction.CallbackContext context);
            void OnHandbrake(InputAction.CallbackContext context);
            void OnReset(InputAction.CallbackContext context);
        }
        public interface IUIActions
        {
            void OnPause(InputAction.CallbackContext context);
        }
    }
}
