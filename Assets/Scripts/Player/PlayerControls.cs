using System;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    private Player player;
    private Rigidbody rb;
    private Camera mainCamera;

    [SerializeField] private InputReaderSO m_input;

    private Vector2 moveInput;

    [SerializeField] private float lookSensitivity;
    [SerializeField] private float maxLookUpAngle;
    [SerializeField] private float maxLookDownAngle;
    private Vector2 mouseDelta;
    private float verticalRotation;
    private float horizontalRotation;

    private bool canLookAround = true;

    public event Action Jumped;


    public InputReaderSO input {
        get => m_input;
    }

    public void AddForce(Vector3 dir, float power) {
        rb.AddForce(dir * power, ForceMode.Impulse);
    }

    private void Awake() {
        mainCamera = Camera.main;

        player = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        Look();
    }

    private void FixedUpdate() {
        Move();
    }

    private void OnEnable() {
        input.moveEvent += OnMove;
        input.lookEvent += OnLook;
        input.jumpEvent += OnJump;
        input.inventoryEvent += OnInventoryEvent;
    }


    private void OnDisable() {
        input.moveEvent -= OnMove;
        input.lookEvent -= OnLook;
        input.jumpEvent -= OnJump;
        input.inventoryEvent -= OnInventoryEvent;
    }

    private void OnMove(Vector2 dir) {
        moveInput = dir;
    }

    private void Move() {
        Vector3 dir = transform.forward * moveInput.y + transform.right * moveInput.x;
        dir *= player.moveSpeed;
        dir.y = rb.velocity.y;
        rb.velocity = dir;
    }

    private void OnLook(Vector2 delta) {
        mouseDelta = delta;
    }

    private void Look() {
        if (!canLookAround) {
            return;
        }

        horizontalRotation += mouseDelta.x * lookSensitivity;
        transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);

        verticalRotation -= mouseDelta.y * lookSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, maxLookDownAngle, maxLookUpAngle);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    private void OnJump() {
        if (player.isGrounded) {
            rb.AddForce(Vector3.up * player.jumpPower, ForceMode.Impulse);
            Jumped?.Invoke();
        }
    }

    private void OnInventoryEvent() {
        canLookAround = !canLookAround;
    }
}
