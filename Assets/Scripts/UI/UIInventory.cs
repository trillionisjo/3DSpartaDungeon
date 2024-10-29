    using UnityEngine;

public class UIInventory : MonoBehaviour {
    [SerializeField] private GameObject contents;

    private ItemSlot[] slots;

    public UIInventory() {
        Global.uiInventory = this;
    }

    private void Awake() {
        //Global.uiInventory = this;
    }

    private void Start() {
        slots = new ItemSlot[contents.transform.childCount];

        for (int i = 0; i < slots.Length; i++) {
            slots[i] = contents.transform.GetChild(i).GetComponent<ItemSlot>();
            slots[i].UpdateUI();
        }
    }
}
