using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderItem : MonoBehaviour
{
    [SerializeField] public bool isPlaceholder;
    [SerializeField] public int collisionCount;
    [SerializeField] public bool isValid;
    [SerializeField] Material placeholderMaterial;
    [SerializeField] Material originalMaterial;
    [SerializeField] public GameObject playerObj;
    [SerializeField] GameObject placeholder;
    [SerializeField] string originalTag;

    void Start() {
        isValid = true;
    }

    void OnTriggerEnter(Collider other) {
        if (isPlaceholder && other.tag != "Ground") {
            collisionCount += 1;
            if (isValid) {
                Renderer rend = gameObject.GetComponent<Renderer>();
                foreach (Material mat in rend.materials) {
                    mat.SetInt("IsValid", Convert.ToInt32(false));
                }
                isValid = false;
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (isPlaceholder && other.tag != "Ground") {
            collisionCount -= 1;
            if (!isValid && collisionCount == 0) {
                Renderer rend = gameObject.GetComponent<Renderer>();
                foreach (Material mat in rend.materials) {
                    mat.SetInt("IsValid", Convert.ToInt32(true));
                }
                isValid = true;

            }
        }
    }

    public void TogglePlaceholderScript(bool isEnabled) {
        isPlaceholder = isEnabled;
        gameObject.tag = isEnabled ? "Untagged" : originalTag;
        gameObject.GetComponent<Renderer>().material = isEnabled ?
            placeholderMaterial :
            originalMaterial;
    }

}
