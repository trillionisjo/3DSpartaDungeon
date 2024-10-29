using UnityEngine;

public class PlayerSounds : MonoBehaviour {
    private InputReaderSO input;
    private Rigidbody rb;
    private PlayerControls controls;

    [SerializeField] private float footstepThreshold;
    [SerializeField] private float footstepVThreadshold;
    [SerializeField] private float footstepDelay;
    private float footstepLastTime;

    private void Awake() {
        controls = GetComponent<PlayerControls>();
        input = GetComponent<PlayerControls>().input;
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        controls.Jumped += OnJumped;

    }

    private void OnDisable() {
        controls.Jumped -= OnJumped;
    }

    private void Update() {
        FootstepSound();
    }

    private void FootstepSound() {
        if (Mathf.Abs(rb.velocity.y) < footstepVThreadshold) {
            var horizontalVelocity = new Vector2(rb.velocity.x, rb.velocity.z);
            if (horizontalVelocity.magnitude > footstepThreshold) {
                var time = Time.time;
                if (time - footstepLastTime > footstepDelay) {
                    footstepLastTime = time;
                    int index = Random.Range((int)AudioClipName.Footsteps_Tile_Walk_01, (int)AudioClipName.Footsteps_Tile_Walk_08);
                    var clip = Audio.GetAudioClip((AudioClipName)index);
                    SoundManagerSO.PlaySoundFxClip(clip, transform.position, 1f);
                }
            }
        }
    }

    private void OnJumped() {
        var clip = Audio.GetAudioClip(AudioClipName.Footsteps_Tile_Jump_Land_03);
        SoundManagerSO.PlaySoundFxClip(clip, transform.position, 1f);
    }
}
