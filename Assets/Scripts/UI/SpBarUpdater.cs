using UnityEngine;

public class SpBarUpdater : BarUpdater {
    protected override void UpdateBar() {
        if (Global.player == null) {
            return;
        }
        if (Global.player.stamina == value) {
            return;
        }
        value = Global.player.stamina;
        valueText.text = value.ToString();
        bar.fillAmount = (float)value / Global.player.maxStamina;
    }
}
