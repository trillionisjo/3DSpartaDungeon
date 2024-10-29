using UnityEngine;

public class ItemObject : MonoBehaviour {
    public ItemType type;
    public Item item;

    private void Awake() {
        item = ItemFactory.Create(type);
    }
}
