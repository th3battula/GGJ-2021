using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour {
    [SerializeField] float movementSpeed;
    Vector3 endPosition;
    [SerializeField] float detectionChance;
    // Start is called before the first frame update
    void Start() {
        endPosition = GameObject.Find("DroneEnd").transform.position;
    }

    // Update is called once per frame
    void Update() {
        float step =  movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, endPosition, step);

        GameObject firePit = GameObject.FindGameObjectWithTag("FirePit");
        if (firePit) {
            float randValue = Random.Range(0, 1f);
            bool didFindFire = randValue <= detectionChance;
            if (didFindFire) {
                Debug.Log("YOU WIN!!!!!!111!!1!11");
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.name == "DroneEnd") {
            Destroy(gameObject);
        }
    }

}
