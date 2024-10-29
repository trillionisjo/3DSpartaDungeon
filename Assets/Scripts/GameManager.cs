using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private InputReaderSO input;

    public static void ShowCursor() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public static void HideCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Awake() {
        Audio.LoadAudioClips();
    }

    private void Start() {
        HideCursor();
    }

    private void OnEnable() {
        input.inventoryEvent += OnInventoryEvent;
    }

    private void OnDisable() {
        input.inventoryEvent -= OnInventoryEvent;
    }

    private void OnInventoryEvent() {
        var obj = Global.uiInventory.gameObject;
        if (obj.activeInHierarchy) {
            obj.SetActive(false);
            HideCursor();
        } else {
            obj.SetActive(true);
            ShowCursor();
        }

    }
}
