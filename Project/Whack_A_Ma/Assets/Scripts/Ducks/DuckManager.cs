using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] spawnPoints;
    [SerializeField]
    private GameObject duckPrefab;
    private GameObject currentSpawnPoint;
    private bool hasSpawned;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] ducks = GameObject.FindGameObjectsWithTag("Bird");
        if (!hasSpawned && (ducks.Length < 10)) {
            hasSpawned = true;
            StartCoroutine("SpawnDuck");
        }
	}

    IEnumerator SpawnDuck() {
        yield return new WaitForSeconds(Random.Range(1f, 2f));
        int index = Random.Range(1, spawnPoints.Length);
        currentSpawnPoint = spawnPoints[index];
        Instantiate(duckPrefab, currentSpawnPoint.transform);
        hasSpawned = false;
    }

}
