using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int startingWaveSize = 1;
    public int waveSizeIncrement = 1;
    public float spawnDistance = 10f;
    public float waveDuration = 5f;

    private int currentWaveSize;

    // Start is called before the first frame update
    void Start()
    {
        currentWaveSize = startingWaveSize;
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            SpawnWave();
            yield return new WaitForSeconds(waveDuration);
            currentWaveSize += waveSizeIncrement;
        }
    }

    void SpawnWave()
    {
        for (int i = 0; i < currentWaveSize; i++)
        {
            // Calculate a random direction for enemy spawn
            Vector3 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPosition = transform.position + randomDirection * spawnDistance;

            // Instantiate the enemy prefab at the spawn position
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
