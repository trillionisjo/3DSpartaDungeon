using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HpBarUpdater : BarUpdater {
    protected override void UpdateBar() {
        if (Global.player == null) {
            return;
        }
        if (Global.player.health == value) {
            return;
        }
        value = Global.player.health;
        valueText.text = value.ToString();
        bar.fillAmount = (float)value / Global.player.maxHealth;
    }
}