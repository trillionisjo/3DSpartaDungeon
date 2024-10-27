using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName ="Scriptable Objects/Input Reader", fileName ="InputReader")]
public class InputReaderSO : ScriptableObject, Controls.IPlayerActions {
    [SerializeField] private InputActionAsset asset;

    public event Action<Vector2> moveEvent;
    public event Action<Vector2> lookEvent;
    public event Action jumpEvent;

    private Controls controls;

    private void OnEnable() {
        if (controls == null) {
            controls = new Controls();
            controls.Player.SetCallbacks(this);
        }
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }

    public void OnMove(InputAction.CallbackContext context) {
        moveEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnLook(InputAction.CallbackContext context) {
        lookEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context) {
        switch (context.phase) {
        case InputActionPhase.Started:
            jumpEvent?.Invoke();
            break;
        }
    }
}
