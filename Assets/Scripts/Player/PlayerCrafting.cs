using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrafting : MonoBehaviour {
    [SerializeField] GameObject firePit;
    [SerializeField] public float spawnDistance = 5f;
    [SerializeField] public GameObject objectToCraft = null;
    [SerializeField] Inventory.ItemTypes craftingIngredient = Inventory.ItemTypes.Stick;
    [SerializeField] int craftingIngredientCountRequirement = 5;
    [SerializeField] GameObject craftingPlaceholderPrefab;
    [SerializeField] GameObject groundObj;
    [SerializeField] public GameObject activeCraftingPlaceholder;
    [SerializeField] bool isCrafting = false;

    PlayerInventory playerInventory;

    void Start() {
        groundObj = GameObject.FindGameObjectWithTag("Ground");
    }

    void Update() {

        int ingredientCount = PlayerInventory.current.GetInventory.GetItemCount(craftingIngredient);
        if (
            Input.GetButtonDown("Craft") &&
            !isCrafting &&
            ingredientCount >= craftingIngredientCountRequirement
        ) {
            objectToCraft = firePit;
            Vector3 spawnPos = GetPlaceholderPosition();
            activeCraftingPlaceholder = Instantiate(craftingPlaceholderPrefab, spawnPos, Quaternion.identity);
            isCrafting = true;
        } else if (isCrafting) {
            if (Input.GetButtonDown("Fire2")) {
                objectToCraft = null;
                isCrafting = false;
                Destroy(activeCraftingPlaceholder);
            }
            Vector3 newPos = GetPlaceholderPosition();
            activeCraftingPlaceholder.transform.position = newPos;
        }
    }

    Vector3 GetPlaceholderPosition() {
        Vector3 spawnPos = transform.position + transform.forward * spawnDistance;
        return new Vector3(spawnPos.x, groundObj.transform.position.y, spawnPos.z);
    }

    public void PlaceObject() {
        objectToCraft = null;
        isCrafting = false;
        PlayerInventory.current.GetInventory.AdjustItemInventoryCount(craftingIngredient, -craftingIngredientCountRequirement);
    }
}
