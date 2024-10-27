using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PromptText : MonoBehaviour {
    private TextMeshProUGUI text;

    private void Awake() {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start() {
        if (Global.player != null && Global.player.interaction != null) {
            Global.player.interaction.InteractionEvent += OnInteractionEvent;
        }
    }

    private void OnDestroy() {
        if (Global.player != null && Global.player.interaction != null) {
            Global.player.interaction.InteractionEvent -= OnInteractionEvent;
        }
    }

    private void OnInteractionEvent(GameObject obj) {
        text.text = (obj == null ? string.Empty : obj.name);
    }
}