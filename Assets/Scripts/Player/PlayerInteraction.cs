using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour {
    private Camera mainCamera;

    [SerializeField] private float checkDelay = 0.1f;
    [SerializeField] private float lastCheckTime = 0f;
    [SerializeField] private float maxCheckDistance = 0.5f;

    public event Action<GameObject> InteractionEvent;

    private GameObject currentTarget;

    private void Awake() {
        mainCamera = Camera.main;
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
