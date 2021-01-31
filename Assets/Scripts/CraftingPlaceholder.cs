using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingPlaceholder : MonoBehaviour
{
    [SerializeField] public GameObject objectToCraft;
    [SerializeField] public GameObject playerObj;
    [SerializeField] GameObject placeholder;

    void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        objectToCraft = playerObj.GetComponent<PlayerCrafting>().objectToCraft;
        placeholder = Instantiate(objectToCraft, transform.position, Quaternion.identity);
        placeholder.transform.SetParent(gameObject.transform);
    }

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            placeholder.transform.SetParent(null);
            playerObj.GetComponent<PlayerCrafting>().PlaceObject();
            Destroy(gameObject);
        }
    }
}
