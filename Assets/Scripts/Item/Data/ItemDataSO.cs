using UnityEngine;

public enum ItemType {
    None,
    StaminaPotion,
}

[CreateAssetMenu(menuName = "Scriptable Objects/Item Data", fileName = "New ItemData")]
public class ItemDataSO : ScriptableObject {
    public ItemType type;
    public string itemName;
    public string description;

    public GameObject prefab;
    public Sprite icon;

    public bool canStack;
    public int maxStackCount;

    public int healthRestoreAmount;
    public int staminaResotreAmount;
}
