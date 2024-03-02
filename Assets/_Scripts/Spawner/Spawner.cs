using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class EnemyWave
{
    public GameObject[] enemyPrefabs; 
}

public class Spawner : MonoBehaviour
{
    public EnemyWave[] waves; 
    public float timeBetweenWaves = 5f; 
    public float timeBeforeFirstWave = 2f; 
    public Vector2 spawnAreaSize = new Vector2(10f, 10f); 
    public Transform[] spawnPoints;
    private bool Endless;
    public bool shallBeEndless;
    public int maxWaveIndex;
    public LevelManager levelManager;

    private int waveIndex = 0; 

    void Start()
    {
        
        Invoke("SpawnWave", timeBeforeFirstWave);
    }

    void SpawnWave()
    {

        if(Endless == false)
        {
            if (waveIndex < waves.Length)
            {

                GameObject[] enemiesToSpawn = waves[waveIndex].enemyPrefabs;

                // Pêtla przez wszystkie punkty spawnu
                foreach (Transform spawnPoint in spawnPoints)
                {
                    // Losowy punkt wewn¹trz obszaru
                    Vector2 randomPoint = spawnPoint.position + new Vector3(Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2), 0, Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2));

                    // Spawnowanie przeciwnika w losowym miejscu na obszarze
                    GameObject enemyPrefab = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)];
                    Instantiate(enemyPrefab, randomPoint, Quaternion.identity);
                }

                // Zwiêkszenie indeksu fali
                waveIndex++;

                // Uruchomienie kolejnej fali po czasie miêdzy falami
                Invoke("SpawnWave", timeBetweenWaves);

                if(shallBeEndless == true)
                {
                    if (waveIndex >= maxWaveIndex)
                    {
                        Endless = true;
                    }
                }
                else
                {
                    levelManager.NextLevel();
                }
                
            }
        }
        else
        {
            GameObject[] enemiesToSpawn = waves[Random.Range(1,maxWaveIndex)].enemyPrefabs;

            // Pêtla przez wszystkie punkty spawnu
            foreach (Transform spawnPoint in spawnPoints)
            {
                // Losowy punkt wewn¹trz obszaru
                Vector2 randomPoint = spawnPoint.position + new Vector3(Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2), 0, Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2));

                // Spawnowanie przeciwnika w losowym miejscu na obszarze
                GameObject enemyPrefab = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)];
                Instantiate(enemyPrefab, randomPoint, Quaternion.identity);
            }

            // Zwiêkszenie indeksu fali
            waveIndex++;

            // Uruchomienie kolejnej fali po czasie miêdzy falami
            Invoke("SpawnWave", timeBetweenWaves);
        }
    }
    }
        
      



