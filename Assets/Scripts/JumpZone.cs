using UnityEngine;

public class JumpZone : MonoBehaviour {
    [field: SerializeField] public Vector3 direction { get; private set; }
    [field: SerializeField] public float power { get; private set; }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            var controls = other.gameObject.GetComponent<PlayerControls>();
            controls.AddForce(direction, power);
        }
    }
}
