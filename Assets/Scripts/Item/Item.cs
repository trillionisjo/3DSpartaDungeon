using UnityEngine;

public abstract class Item {
    public ItemDataSO data;
    public int stackCount;

    public abstract void Use(Player player);
}
