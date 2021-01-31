using System;
using System.Collections.Generic;

[Serializable]
public class Inventory {
    public enum ItemTypes {
        Stick,
    };

    Dictionary<ItemTypes, int> itemCounts;

    public Inventory() {
        itemCounts = new Dictionary<ItemTypes, int>();
    }

    public int AdjustItemInventoryCount(ItemTypes itemType, int amountToAdd = 1) {
        if (itemCounts.ContainsKey(itemType)) {
            itemCounts[itemType] += amountToAdd;
        } else {
            itemCounts.Add(itemType, amountToAdd);
        }

        return GetItemCount(itemType);
    }

    public int GetItemCount(ItemTypes itemType) {
        int count = 0;

        itemCounts.TryGetValue(itemType, out count);

        return count;
    }
}