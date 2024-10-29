using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour {
    private static ItemSlot currentItemSlot = null;

    [Header("Components")]
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI countText;
    [SerializeField] private Button button;
    [SerializeField] private Outline outline;

    [Header("Slot Data")]
    public ItemData item;
    public int index;


    private void Start() {
        button.onClick.AddListener(OnButtonClicked);
    }

    // �ڽ��ǹ�ư��Ŭ���Ǿ�����.
    private void OnButtonClicked() {
        if (currentItemSlot == this) {
            UseItem();
        } else {
            if (currentItemSlot != null) {
                currentItemSlot.outline.enabled = false;
            }
            currentItemSlot = this;
            currentItemSlot.outline.enabled = true;
        }
    }

    // ��밡���ѽ����ΰ�?
    public bool IsSlotAvailable() {
        if (item == null) {
            return false;
        }
        if (item.stackCount <= 0) {
            return false;
        }
        return true;
    }

    // �߰������ѽ����ΰ�?
    public bool IsSlotAddable() {
        if (item == null) {
            return true;
        }
        if (item.stackCount < item.data.maxStackCount) {
            return true;
        }
        return false;
    }

    // �����ۻ���ϱ�.
    public void UseItem() {
        if (!IsSlotAvailable()) {
            return;
        }
    }

    public void UpdateUI() {
        if (item == null) {
            icon.sprite = null;
            countText.text = string.Empty;
        } else {
            icon.sprite = item.data.icon;
            countText.text = item.stackCount.ToString();
        }
    }
}
