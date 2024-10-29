using UnityEngine;

public static class ItemFactory {
    public static Item Create(ItemType type) {
        switch (type) {
        case ItemType.StaminaPotion:
            return new StaminaPotionItem();

        default:
            return null;
        }
    }
}
