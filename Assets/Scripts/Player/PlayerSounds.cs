using UnityEngine;

public class PlayerSounds : MonoBehaviour {
    private InputReaderSO input { get; set; }
    private Rigidbody rb { get; set; }

    [field: SerializeField] private float footstepThreshold { get; set; }
    [field: SerializeField] private float footstepVThreadshold { get; set; }
    [field: SerializeField] private float footstepDelay { get; set; }
    private float footstepLastTime { get; set; }

    private void Awake() {
        input = GetComponent<PlayerControls>().input;
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        input.jumpEvent += OnJump;
    }

    private void OnDisable() {
        input.jumpEvent -= OnJump;
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
                    int index = Random.Range((int)AudioFileName.Footsteps_Tile_Walk_01, (int)AudioFileName.Footsteps_Tile_Walk_08);
                    var clip = AudioClipsSO.GetClip((AudioFileName)index);
                    SoundManagerSO.PlaySoundFxClip(clip, transform.position, 1f);
                }
            }
        }
    }

    private void OnJump() {
        var clip = AudioClipsSO.GetClip(AudioFileName.Footsteps_Tile_Jump_Land_03);
        SoundManagerSO.PlaySoundFxClip(clip, transform.position, 1f);
    }
}
