public class Stick : Interactable {
    public override void Interact() {
        base.Interact();
        this.Disable();
        PlayerInventory.current.AddToInventory(Inventory.ItemTypes.Stick);
    }
}
