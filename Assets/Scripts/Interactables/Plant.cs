using UnityEngine;

public class Plant : Interactable {
    [SerializeField] float needAdjustment = 10f;
    [SerializeField] PlayerNeeds.Type playerNeedType;
    [SerializeField] float maxResetTimer = 15f;
    [SerializeField] GameObject itemToDisable;

    bool isDepleted = false;
    float resetTimer;

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
        this.IsHighlightingDisabled = true;
        itemToDisable.SetActive(false);
    }

    void ResetResource() {
        isDepleted = false;
        resetTimer = maxResetTimer;
        this.IsHighlightingDisabled = false;
        itemToDisable.SetActive(true);
    }
}
