using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Interactable {
    public override void Interact() {
        base.Interact();
        PlayerNeeds.current.AdjustNeed(10f, PlayerNeeds.Type.Hunger);
    }
}
