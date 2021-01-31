using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNeeds : MonoBehaviour {
    public enum Type {
        Hunger,
        Thirst
    };

    public static PlayerNeeds current;
    [SerializeField] float hungerLevel;
    [SerializeField] float thirstLevel;
    [SerializeField] float hungerDropModifier = 1;
    [SerializeField] float thirstDropModifier = 1;
    [SerializeField] float maxHungerLevel = 100;
    [SerializeField] float maxThirstLevel = 100;

    // Start is called before the first frame update
    void Start() {
        current = this;
        hungerLevel = maxHungerLevel;
        thirstLevel = maxThirstLevel;
    }

    // Update is called once per frame
    void Update() {
        DepleteNeeds();
    }

    void DepleteNeeds() {
        hungerLevel -= hungerDropModifier * Time.deltaTime;
        thirstLevel -= thirstDropModifier * Time.deltaTime;

        if (hungerLevel <= 0) {
            Debug.Log("You are dying of hunger");
        }

        if (thirstLevel <= 0) {
            Debug.Log("You are dying of thirst");
        }
    }

    public void AdjustNeed(float adjustAmount, Type needType) {
        switch (needType) {
            case Type.Hunger:
                this.hungerLevel = Mathf.Clamp(this.hungerLevel + adjustAmount, 0, maxHungerLevel);
                break;
            case Type.Thirst:
                this.thirstLevel = Mathf.Clamp(this.thirstLevel + adjustAmount, 0, maxThirstLevel);
                break;
        }
    }
}
