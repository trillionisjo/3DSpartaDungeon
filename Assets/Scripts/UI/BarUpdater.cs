using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BarUpdater : MonoBehaviour {
    protected Image bar;
    protected TextMeshProUGUI valueText;
    protected int value;

    private void Start() {
        bar = GetComponent<Image>();
        valueText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update() {
        UpdateBar();
    }

    protected abstract void UpdateBar();
}
