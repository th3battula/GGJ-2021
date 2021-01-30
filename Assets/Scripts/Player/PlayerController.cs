using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
    [SerializeField] Transform cameraTransform;
    [SerializeField] LayerMask raycastLayermask;
    [SerializeField] float raycastDistance = 5.0f;

    void Update() {
        RaycastHit hit;

        if (Physics.Raycast(cameraTransform.position, cameraTransform.rotation * Vector3.forward, out hit, raycastDistance, raycastLayermask)) {
            Interactable interactable = hit.transform.gameObject.GetComponent<Interactable>();

            if (interactable) {
                interactable.SetIsHovering(true);

                if (Input.GetButtonDown("Interact")) {
                    interactable.Interact();
                }
            }
        }
    }
}
