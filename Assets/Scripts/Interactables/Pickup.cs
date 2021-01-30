using UnityEngine;

public class Pickup : Interactable {
    public enum PickupType {}

    [SerializeField] PickupType pickupType;

    public override void Interact() {
        DestroyImmediate(this.gameObject);
    }

    public PickupType GetPickupType {
        get {
            return pickupType;
        }
    }
}
