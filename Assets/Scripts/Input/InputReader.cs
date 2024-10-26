using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName ="Input/Input Reader", fileName ="InputReader")]
public class InputReader : ScriptableObject {
    [SerializeField] private InputActionAsset asset;
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction jumpAction;

    public event Action<Vector2> moveEvent;
    public event Action<Vector2> lookEvent;
    public event Action jumpEvent;


    private void OnEnable() {
        moveAction = asset.FindAction("Move");
        lookAction = asset.FindAction("Look");
        jumpAction = asset.FindAction("Jump");

        moveAction.started += OnMove;
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;

        lookAction.started += OnLook;
        lookAction.performed += OnLook;
        lookAction.canceled += OnLook;

        jumpAction.started += OnJump;

        moveAction.Enable();
        lookAction.Enable();
        jumpAction.Enable();
    }

    private void OnDisable() {
        moveAction.Disable();
        lookAction.Disable();
        jumpAction.Disable();

        moveAction.started -= OnMove;
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;

        lookAction.started -= OnLook;
        lookAction.performed -= OnLook;
        lookAction.canceled -= OnLook;

        jumpAction.started -= OnJump;
    }

    private void OnJump(InputAction.CallbackContext context) {
        jumpEvent?.Invoke();
    }

    private void OnLook(InputAction.CallbackContext context) {
        lookEvent?.Invoke(context.ReadValue<Vector2>());
    }

    private void OnMove(InputAction.CallbackContext context) {
        moveEvent?.Invoke(context.ReadValue<Vector2>());
    }
}
