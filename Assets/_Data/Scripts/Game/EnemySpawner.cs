using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;
    public int numberEnemy = 3;
    public int currentNumEnemy = 0;
    public int numEnemyDie = 0;
    public int numDie = 0;
    private void Awake()
    {
        instance = this;
    }
    public List<GameObject> enemyPrefabs;
    public List<Transform> spawnPoints;
    public float spawTime = 3f;

    public float waveCountDown;
    private void Update()
    {
        numEnemyDie = numDie;
    }
    public void StartSpawning()
    {
        //call spawn coroutine
        StartCoroutine(SpawnDelay());
    }
    IEnumerator SpawnDelay()
    {
        //call spawn method
        SpawnEnemy();
        currentNumEnemy++;
        //wait spawn time
        yield return new WaitForSeconds(spawTime);
        //recall same coroutine 
        if (numberEnemy > currentNumEnemy)
        {
            StartCoroutine(SpawnDelay());
        }
        else
        {
            StopAllCoroutines();
        }
    }
    private void SpawnEnemy()
    {
        //random enemy
        int randomEnemyID = Random.Range(0, enemyPrefabs.Count);
        //random spawn point
        int randomSpawnPointID = Random.Range(0, spawnPoints.Count);
        //instiate enemy prefabs
        GameObject spawnedEnemy = Instantiate(enemyPrefabs[randomEnemyID], spawnPoints[randomSpawnPointID]);
    }
}
