using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNeeds : MonoBehaviour
{
    [SerializeField] float hungerLevel;
    [SerializeField] float thirstLevel;
    [SerializeField] float hungerDropModifier = 1;
    [SerializeField] float thirstDropModifier = 1;
    const float maxHungerLevel = 100;
    const float maxThirstLevel = 100;

    // Start is called before the first frame update
    void Start() {
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
}
