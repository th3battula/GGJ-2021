using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Interactable {
    [SerializeField] bool isDepleted = false;
    [SerializeField] float needAdjustment = 10f;
    [SerializeField] PlayerNeeds.Type playerNeedType;
    [SerializeField] float resetTimer;
    [SerializeField] float maxResetTimer = 15f;

    void Start() {
        resetTimer = maxResetTimer;
    }

    void Update() {
        if (isDepleted) {
            resetTimer -= Time.deltaTime;
            if (resetTimer <= 0) {
                ResetResource();
            }
        }
    }

    public override void Interact() {
        if (!isDepleted) {
            base.Interact();
            PlayerNeeds.current.AdjustNeed(needAdjustment, playerNeedType);
            DepleteResource();
        }
    }

    void DepleteResource() {
        isDepleted = true;
        this.isHighlightingDisabled = true;
    }

    void ResetResource() {
        isDepleted = false;
        resetTimer = maxResetTimer;
        this.isHighlightingDisabled = false;
    }
}
