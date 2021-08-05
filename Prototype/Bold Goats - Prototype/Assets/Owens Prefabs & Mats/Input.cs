// GENERATED AUTOMATICALLY FROM 'Assets/Owens Prefabs & Mats/Input.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Input : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Input()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Input"",
    ""maps"": [
        {
            ""name"": ""Game"",
            ""id"": ""da9ad0d4-9232-4932-9e5e-171473a577d0"",
            ""actions"": [
                {
                    ""name"": ""Forward"",
                    ""type"": ""Button"",
                    ""id"": ""1a07a24f-c848-4053-86a0-f78fc84f7a29"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Backward"",
                    ""type"": ""Button"",
                    ""id"": ""946c1abe-7383-4280-a19e-1ad6df6f66aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""c0a6114f-ee42-42fa-9a78-ff4082890e73"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""dca251f7-7c78-49c9-b909-d42416f4636f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""29121c4e-2943-40cb-9414-bf7a9adb1781"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Distraction"",
                    ""type"": ""Button"",
                    ""id"": ""f836a207-1080-4b26-9928-cb6bf9dd05c9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""68c81b71-8fc3-4fd4-a96c-ad1992a7a0e5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""07488ca0-1e22-442b-8c0a-58566394b340"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2a0e96e8-a1bc-4f3f-86a8-4af144212c2a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Forward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""19e88489-73ef-4787-b2a8-cb8360f1905d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""105637ee-4f74-42e2-98b2-16260ea01c92"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Backward"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bac7a9b-cef6-4515-a78e-9cc40b4a185b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6316c524-dbad-49c8-b775-96d88d66f251"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""258627c3-537a-44dd-aae0-9ca2bc2f9a27"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1a8eb31-5492-4cfe-a0d8-40e0ba29caa3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7ea55828-78f9-4b51-b842-da1a1fddcd31"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e38b1c48-84b2-4a94-ae77-62a2f4220c48"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Distraction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1c0ad250-d8a3-43a8-8aed-373e4233489a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Forward = m_Game.FindAction("Forward", throwIfNotFound: true);
        m_Game_Backward = m_Game.FindAction("Backward", throwIfNotFound: true);
        m_Game_Left = m_Game.FindAction("Left", throwIfNotFound: true);
        m_Game_Right = m_Game.FindAction("Right", throwIfNotFound: true);
        m_Game_Run = m_Game.FindAction("Run", throwIfNotFound: true);
        m_Game_Distraction = m_Game.FindAction("Distraction", throwIfNotFound: true);
        m_Game_Interact = m_Game.FindAction("Interact", throwIfNotFound: true);
    }

    internal static bool GetKeyDown(KeyCode r)
    {
        throw new NotImplementedException();
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

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Forward;
    private readonly InputAction m_Game_Backward;
    private readonly InputAction m_Game_Left;
    private readonly InputAction m_Game_Right;
    private readonly InputAction m_Game_Run;
    private readonly InputAction m_Game_Distraction;
    private readonly InputAction m_Game_Interact;
    public struct GameActions
    {
        private @Input m_Wrapper;
        public GameActions(@Input wrapper) { m_Wrapper = wrapper; }
        public InputAction @Forward => m_Wrapper.m_Game_Forward;
        public InputAction @Backward => m_Wrapper.m_Game_Backward;
        public InputAction @Left => m_Wrapper.m_Game_Left;
        public InputAction @Right => m_Wrapper.m_Game_Right;
        public InputAction @Run => m_Wrapper.m_Game_Run;
        public InputAction @Distraction => m_Wrapper.m_Game_Distraction;
        public InputAction @Interact => m_Wrapper.m_Game_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Forward.started -= m_Wrapper.m_GameActionsCallbackInterface.OnForward;
                @Forward.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnForward;
                @Forward.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnForward;
                @Backward.started -= m_Wrapper.m_GameActionsCallbackInterface.OnBackward;
                @Backward.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnBackward;
                @Backward.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnBackward;
                @Left.started -= m_Wrapper.m_GameActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_GameActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnRight;
                @Run.started -= m_Wrapper.m_GameActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnRun;
                @Distraction.started -= m_Wrapper.m_GameActionsCallbackInterface.OnDistraction;
                @Distraction.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnDistraction;
                @Distraction.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnDistraction;
                @Interact.started -= m_Wrapper.m_GameActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Forward.started += instance.OnForward;
                @Forward.performed += instance.OnForward;
                @Forward.canceled += instance.OnForward;
                @Backward.started += instance.OnBackward;
                @Backward.performed += instance.OnBackward;
                @Backward.canceled += instance.OnBackward;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @Distraction.started += instance.OnDistraction;
                @Distraction.performed += instance.OnDistraction;
                @Distraction.canceled += instance.OnDistraction;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    public interface IGameActions
    {
        void OnForward(InputAction.CallbackContext context);
        void OnBackward(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnDistraction(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
