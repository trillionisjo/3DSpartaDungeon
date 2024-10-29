using UnityEngine;

public class JumpZone : MonoBehaviour {
    [SerializeField] private Vector3 direction;
    [SerializeField] private float power;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null) {
                player.controls?.AddForce(direction, power + player.jumpPower);
            }
        }
    }
}
