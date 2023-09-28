using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public List<Wave> waves; 
    private int currentWaveIndex = 0; 
    private int remainingEnemies;
    private string sceneName;
    private PlayerMovement player;

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
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
            PlayerDataManager playerDataManager = GameObject.Find("PlayerDataManager")?.GetComponent<PlayerDataManager>();
            PlayerData playerData = playerDataManager.playerData;
            playerData.playerDamage = player.Damage;
            playerData.playerHealth = player.Health;
            playerData.playerSpeed = player.Speed;
            playerData.playerBulletCooldown = player.BulletCoolDown;
            playerData.playerSlowDown = player.IsSlowedDownShooting;

            if (sceneName == "SampleScene") {
                SceneManager.LoadScene("Stage2");
            }
            if (sceneName == "Stage2")
            {
                SceneManager.LoadScene("Stage3");
            }
            if (sceneName == "Stage3")
            {
                if (!PlayerPrefs.HasKey("BestTime"))
                {
                    PlayerPrefs.SetFloat("BestTime", GameObject.Find("Timer").GetComponentInChildren<Timer>().Time);
                    PlayerPrefs.Save();
                }
                if (PlayerPrefs.GetFloat("BestTime") > GameObject.Find("Timer").GetComponentInChildren<Timer>().Time) {
                    PlayerPrefs.SetFloat("BestTime", GameObject.Find("Timer").GetComponentInChildren<Timer>().Time);
                    PlayerPrefs.Save();
                }
                SceneManager.LoadScene("Ending");
            }
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
