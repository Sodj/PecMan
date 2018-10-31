using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] ghostFormations;
    public float spawnInterval = 5;
    public float minSpawnInterval = 4;
    public float timeSinceLastSpawn = 0;
    public float acceleration = 0.05f;

	void Update () {
        int rand = Random.Range(0, ghostFormations.Length);
		if(timeSinceLastSpawn <= 0){
            Instantiate(ghostFormations[rand], transform.position, Quaternion.identity);
            timeSinceLastSpawn = spawnInterval;
            if(spawnInterval > minSpawnInterval) spawnInterval -= acceleration;
            else spawnInterval = minSpawnInterval;
        }
        else timeSinceLastSpawn -= Time.deltaTime;
	}
}
