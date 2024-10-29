using UnityEngine;

public class StaminaPotionItem : Item {
    public StaminaPotionItem() {
        data = Resources.Load<ItemDataSO>("StaminaPotionData");
        stackCount = 1;
    }

    public override void Use(Player player) {
        player.stamina += data.staminaResotreAmount;
        stackCount -= 1;
    }
}
