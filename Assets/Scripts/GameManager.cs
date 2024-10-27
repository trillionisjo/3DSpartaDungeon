using UnityEngine;

public class GameManager : MonoBehaviour {
    private void Awake() {
        Global.LoadAudioClips();
    }

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
