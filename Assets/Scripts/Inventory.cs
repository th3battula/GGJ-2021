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

    public int AddItemToInventory(ItemTypes itemType, int amoutToAdd = 1) {
        if (itemCounts.ContainsKey(itemType)) {
            itemCounts[itemType] += amoutToAdd;
        } else {
            itemCounts.Add(itemType, amoutToAdd);
        }

        return GetItemCount(itemType);
    }

    public int GetItemCount(ItemTypes itemType) {
        int count = 0;

        itemCounts.TryGetValue(itemType, out count);

        return count;
    }
}