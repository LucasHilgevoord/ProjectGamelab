using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] spawnPoints;
    [SerializeField]
    private GameObject duckPrefab;
    [SerializeField]
    private GameObject duck2Prefab;

    private GameObject currentSpawnPoint;
    private bool hasSpawned;
    private int ShinyNumber = 7;
	
	// Update is called once per frame
	void Update () 
    {
        if (GameStart.gameStart) {
            GameObject[] ducks = GameObject.FindGameObjectsWithTag("Bird");
            if (!hasSpawned && (ducks.Length < 10)) {
                hasSpawned = true;
                StartCoroutine("SpawnDuck");

            }
        }
	}

    IEnumerator SpawnDuck() {
        yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        ResetSpawnpoint();
        int randomNum = Random.Range(1, 10);
        if(randomNum == ShinyNumber) {
            Instantiate(duck2Prefab, currentSpawnPoint.transform);
        } else {
            Instantiate(duckPrefab, currentSpawnPoint.transform);
        }
        hasSpawned = false;
    }

    void ResetSpawnpoint() {
        int index = Random.Range(1, spawnPoints.Length);
        currentSpawnPoint = spawnPoints[index];
    }

}
