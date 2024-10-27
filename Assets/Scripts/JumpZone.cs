using UnityEngine;

public class JumpZone : MonoBehaviour {
    [SerializeField] private Vector3 direction;
    [SerializeField] private float power;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            var player = other.gameObject.GetComponent<Player>();
            var controls = other.gameObject.GetComponent<PlayerControls>();
            controls.AddForce(direction, power + player.jumpPower);
        }
    }
}
