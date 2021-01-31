using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {
    public static PlayerInventory current;

    [SerializeField] Text stickText;

    Inventory inventory;

    void Start() {
        current = this;
        inventory = new Inventory();
    }

    void Update() {
        stickText.text = String.Format("x {0}", inventory.GetItemCount(Inventory.ItemTypes.Stick));
    }

    public void AddToInventory(Inventory.ItemTypes itemType) {
        inventory.AddItemToInventory(itemType);
    }
}
