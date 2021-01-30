using System;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {
    [SerializeField] Renderer rend;
    [SerializeField] Canvas canvas;
    [SerializeField] Text text;
    [SerializeField] string interactText;

    GameObject mainCamera;

    void Start() {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        text.text = String.Format("Press {0} to {1}", "Interact", interactText);
        text.enabled = false;
    }

    void FixedUpdate() {
        text.enabled = false;
        SetMaterialsShouldHighlight(false);
    }

    void Update() {
        canvas.transform.rotation = Quaternion.LookRotation(transform.position - mainCamera.transform.position);
    }

    public virtual void Interact() {
        Debug.Log(String.Format("Interacted with {0}", gameObject.name));
    }

    public virtual void SetIsHovering(bool isHovering) {
        text.enabled = true;
        SetMaterialsShouldHighlight(isHovering);
    }

    public void SetMaterialsShouldHighlight(bool shouldHighlight) {
        foreach (Material mat in rend.materials) {
            mat.SetInt("ShouldHighlight", Convert.ToInt32(shouldHighlight));
        }
    }

    public void Disable() {
        text.enabled = false;
        SetMaterialsShouldHighlight(false);
        Destroy(this);
    }

    public bool IsHovering {
        get {
            return Convert.ToBoolean(rend.material.GetInt("ShouldHighlight"));
        }
    }
}
