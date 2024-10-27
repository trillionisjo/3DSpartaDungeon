using UnityEngine;

public class PlayerControls : MonoBehaviour {
    [field: SerializeField] public InputReaderSO input { get; private set; }
    private Player player { get; set; }
    private Rigidbody rb { get; set; }
    private Camera mainCamera { get; set; }
    private Vector2 moveInput { get; set; }
    [field: SerializeField] private float lookSensitivity { get; set; }
    [field: SerializeField] private float maxLookUpAngle { get; set; }
    [field: SerializeField] private float maxLookDownAngle { get; set; }
    private Vector2 mouseDelta { get; set; }
    private float verticalRotation { get; set; }
    private float horizontalRotation { get; set; }


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
    }

    private void OnDisable() {
        input.moveEvent -= OnMove;
        input.lookEvent -= OnLook;
        input.jumpEvent -= OnJump;
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
        horizontalRotation += mouseDelta.x * lookSensitivity;
        transform.rotation = Quaternion.Euler(0f, horizontalRotation, 0f);

        verticalRotation -= mouseDelta.y * lookSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, maxLookDownAngle, maxLookUpAngle);
        mainCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    private void OnJump() {
        rb.AddForce(Vector3.up * player.jumpPower, ForceMode.Impulse);
        SoundManagerSO.PlaySoundFxClip(AudioClipsSO.GetClip(AudioFileName.Footsteps_Tile_Jump_Land_03), transform.position, 1f);
    }

    public void AddForce (Vector3 dir, float power) {
        rb.AddForce(dir * power, ForceMode.Impulse);
    }
}
