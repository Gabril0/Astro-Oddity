using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<Wave> waves; 
    private int currentWaveIndex = 0; 
    private int remainingEnemies; 

    void Start()
    {
        startWave();
    }

    private void Update()
    {
        checkWaveEnd();
    }

    void startWave()
    {
        if (currentWaveIndex < waves.Count)
        {
            Wave wave = waves[currentWaveIndex];
            remainingEnemies = wave.enemiesToSpawn.Length;

            for (int i = 0; i < wave.enemiesToSpawn.Length; i++)
            {
                Vector3 spawnPoint = wave.spawnPoints[i];
                GameObject enemyPrefab = wave.enemiesToSpawn[i];


                Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            }
        }
        else
        {
            Debug.Log("Go to next stage");
        }
    }

    public void enemyDefeated()
    {
        remainingEnemies--;   
    }
    private void checkWaveEnd() {
        if (remainingEnemies <= 0)
        {
            currentWaveIndex++;
            startWave();
        }
    }
}
