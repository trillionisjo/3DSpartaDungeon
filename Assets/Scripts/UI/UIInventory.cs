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
        }

        UpdateUISlots();
    }

    public bool AddItem(Item item) {
        ItemSlot slot = null;

        if (item.data.canStack) {
            slot = FindStackSlot(item.data.type);
            if (slot != null) {
                slot.item.stackCount += 1;
                UpdateUISlots();
                return true;
            }
        }

        slot = FindEmptySlot();
        if (slot != null) {
            slot.item = item;
            UpdateUISlots();
            return true;
        }

        return false;
    }

    private ItemSlot FindStackSlot(ItemType type) {
        for (int i = 0; i < slots.Length; i++) {
            if (slots[i].item != null
                && slots[i].item.data.type == type
                && slots[i].item.data.canStack
                && slots[i].item.stackCount < slots[i].item.data.maxStackCount) {
                return slots[i];
            }
        }
        return null;
    }

    private ItemSlot FindEmptySlot() {
        for (int i = 0; i < slots.Length; i++) {
            if (slots[i].item == null) {
                return slots[i];
            }
        }
        return null;
    }

    private void UpdateUISlots() {
        for (int i = 0; i < slots.Length; i++) {
            slots[i].UpdateUI();
        }
    }
}
