using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {
    private Controls controls { get; set; }
    private Rigidbody rb { get; set; }
    private Camera mainCamera { get; set; }
    private Vector2 moveInput { get; set; }
    [field: SerializeField] public float moveSpeed { get; private set; } = 3.5f;
    [field: SerializeField] private float lookSensitivity { get; set; } = 0.3f;
    [field: SerializeField] private float maxLookUpAngle { get; set; } = 90f;
    [field: SerializeField] private float maxLookDownAngle { get; set; } = -90f;
    private Vector2 mouseDelta { get; set; }
    private float verticalRotation { get; set; }
    private float horizontalRotation { get; set; }
    [field: SerializeField] public float jumpForce { get; private set; } = 3f;


    private void Awake() {
        mainCamera = Camera.main;

        rb = GetComponent<Rigidbody>();

        controls = new Controls();
        controls.Player.Move.performed += OnMove;
        controls.Player.Move.canceled += OnMove;

        controls.Player.Look.performed += OnLook;
        controls.Player.Look.canceled += OnLook;

        controls.Player.Jump.started += OnJump;
    }

    private void OnDestroy() {
        controls.Player.Move.performed -= OnMove;
        controls.Player.Move.canceled -= OnMove;

        controls.Player.Look.performed -= OnLook;
        controls.Player.Look.canceled -= OnLook;

        controls.Player.Jump.started -= OnJump;
    }

    private void Update() {
        Look();
    }

    private void FixedUpdate() {
        Move();
    }

    private void OnEnable() {
        controls.Enable();
    }

    private void OnDisable() {
        controls.Disable();
    }

    private void OnMove(InputAction.CallbackContext ctx) {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void Move() {
        Vector3 dir = transform.forward * moveInput.y + transform.right * moveInput.x;
        dir *= moveSpeed;
        dir.y = rb.velocity.y;
        rb.velocity = dir;
    }

    private void OnLook(InputAction.CallbackContext ctx) {
        mouseDelta = ctx.ReadValue<Vector2>();
    }

    private void Look() {
        horizontalRotation += mouseDelta.x * lookSensitivity;
        transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);

        verticalRotation -= mouseDelta.y * lookSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, maxLookDownAngle, maxLookUpAngle);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    private void OnJump(InputAction.CallbackContext ctx) {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
