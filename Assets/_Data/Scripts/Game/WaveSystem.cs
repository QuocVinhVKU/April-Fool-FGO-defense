using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public WaveSystem instance;
    public EnemySpawner[] numWave;
    public int sumEnemy;
    public int currentWave;
    public Int numEnemyDie;
    

    public List<GameObject> spawnPoints;
    public GameObject win_Panel;
    public Victory victory;
    public GameObject gift;
    private void Start()
    {
        StartCoroutine(FirstSpawner());
    }
    private void Update()
    {
        checkWave();
        WinBattle();
    }
    IEnumerator FirstSpawner()
    {
        yield return new WaitForSeconds(25f);
        numWave[0].StartSpawning();
    }
    public void checkWave()
    {
        
        if (numWave[currentWave].waveCountDown <= 0)
        {
            if (currentWave != (numWave.Length - 1))
            {
                currentWave++;
                numWave[currentWave].StartSpawning();

            }
            else if(currentWave == (numWave.Length - 1) && numWave[currentWave].numberEnemy == numWave[currentWave].currentNumEnemy)
            {
                numWave[currentWave].StopAllCoroutines();
            }
        }
        else
        {
            numWave[currentWave].waveCountDown -= Time.deltaTime;
        }

    }
    void WinBattle()
    {
        if (checkClearEnemy())
        {
            StartCoroutine(DelayAfterWin());
        }

    }
    private bool checkClearEnemy()
    {
        if(numEnemyDie.value == sumEnemy)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    IEnumerator DelayAfterWin()
    {
        yield return new WaitForSeconds(1f);
        gift.SetActive(true);
    }
}
