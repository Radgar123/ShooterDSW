using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;


[System.Serializable]
public class EnemyWave
{
    public GameObject[] enemyPrefabs;
    
}

public class Spawner : MonoBehaviour
{
    public EnemyWave[] waves; 
    public float timeBetweenWaves = 5f;
    public float spawnRadius = 5f;
    public float timeBeforeFirstWave = 2f; 
    public Vector2 spawnAreaSize = new Vector2(10f, 10f); 
    public Transform[] spawnPoints;
   [SerializeField] private bool Endless;
    public bool shallBeEndless;
    private int maxWaveIndex;
    public LevelManager levelManager;
    public TextMeshProUGUI waveText;

    private int waveIndex = 0; 

    void Start()
    {
        waveText.text = "Wave: 0";
        maxWaveIndex = waves.Length;
        Invoke("SpawnWave", timeBeforeFirstWave);
    }

    void SpawnWave()
    {

        if(Endless == false)
        {
            if (waveIndex < waves.Length)
            {

                GameObject[] enemiesToSpawn = waves[waveIndex].enemyPrefabs;

             
                
                foreach (Transform spawnPoint in spawnPoints)
                {
                    
                    Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
                    spawnPosition.y = 0;
                
                    GameObject enemyPrefab = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)];
                    Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                }

            
                waveIndex++;
                waveText.text = "Wave: " + waveIndex.ToString();

                
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
                    //levelManager.NextLevel();
                }
                
            }
        }
        else
        {
            GameObject[] enemiesToSpawn = waves[Random.Range(1,maxWaveIndex)].enemyPrefabs;

           
            foreach (Transform spawnPoint in spawnPoints)
            {
            
                Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
                spawnPosition.y = 0;

                
                GameObject enemyPrefab = enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)];
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }

            
            waveIndex++;
            waveText.text = "Wave: " + waveIndex.ToString();
            
            Invoke("SpawnWave", timeBetweenWaves);
        }
    }
    }
        
      



