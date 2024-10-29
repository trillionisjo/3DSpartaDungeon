using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    private Camera mainCamera;
    private InputReaderSO input;

    [SerializeField] private float checkDelay = 0.1f;
    [SerializeField] private float lastCheckTime = 0f;
    [SerializeField] private float maxCheckDistance = 0.5f;

    private GameObject currentTarget;

    public event Action<GameObject> InteractionEvent;


    private void Awake() {
        mainCamera = Camera.main;
        input = GetComponent<PlayerControls>().input;
    }

    private void OnEnable() {
        input.interactinEvent += OnInteractionEvent;
    }

    private void OnInteractionEvent() {
        if (currentTarget == null) {
            return;
        }

        if (currentTarget.TryGetComponent(out ItemObject item)) {
            bool success = Global.uiInventory.AddItem(item.item);
            if (success) {
                Destroy(currentTarget);
                currentTarget = null;
            }
        }
    }

    private void Update() {
        if (Time.time - lastCheckTime >= checkDelay) {
            lastCheckTime = Time.time;

            Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));

            if (Physics.Raycast(ray, out RaycastHit hit, maxCheckDistance)) {
                if (currentTarget != hit.collider.gameObject) {
                    currentTarget = hit.collider.gameObject;
                    InteractionEvent?.Invoke(hit.collider.gameObject);
                }
            } else {
                currentTarget = null;
                InteractionEvent?.Invoke(null);
            }
        }
    }


}
