using System;
using UnityEngine;
using UnityEngine.UI;

public class TestButton : MonoBehaviour {
    private Button button;

    private void Awake() {
        button = GetComponent<Button>();
    }

    private void Start() {
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked() {
        Global.uiInventory.AddItem(new StaminaPotionItem());
    }
}
