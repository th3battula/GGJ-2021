using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour {
    [SerializeField] GameObject dronePrefab;
    [SerializeField] float spawnTimer;
    [SerializeField] float maxSpawnTimer;

    // Start is called before the first frame update
    void Start() {
        spawnTimer = maxSpawnTimer;
    }

    // Update is called once per frame
    void Update() {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0) {
            Instantiate(dronePrefab, GameObject.Find("DroneStart").transform.position, Quaternion.identity);
            spawnTimer = maxSpawnTimer;
        }
    }
}
