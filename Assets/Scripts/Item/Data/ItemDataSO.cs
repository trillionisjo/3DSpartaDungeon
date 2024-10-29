using UnityEngine;

public enum ItemType {
    StaminaPotion,
}

[CreateAssetMenu(menuName = "Scriptable Objects/Item Data", fileName = "New ItemData")]
public class ItemDataSO : ScriptableObject {
    public ItemType type;
    public string itemName;
    public string description;
    public Sprite icon;

    public bool isStackable;
    public int maxStackCount;

    public int healthRestoreAmount;
    public int staminaResotreAmount;
}
