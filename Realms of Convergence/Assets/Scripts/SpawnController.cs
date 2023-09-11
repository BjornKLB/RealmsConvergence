using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    // Variables sorted based on type
    public float spawnDelay = 3f;
    public float currentZombieHealth;
    public float zombiesCalculation;
    public float currentWave = 8f;
    public int maxZombies = 10;
    public int currentZombies = 0;
    public int zombiesSpawned = 0;
    public int zombiesPerWave;
    public int currentPlayers = 3;
    public bool Loaded;

    public GameObject gameobject;
    public GameObject[] spawnPoints;
    public Coroutine SpawnCoroutine;
    public Coroutine NewWaveCoroutine;

    public void Start()
    {
        // Get the zombies spawning
        SpawnCoroutine = StartCoroutine(SpawnWave());

        // check the number of players
        if (currentPlayers == 1)
        {
            zombiesCalculation = 0.000058f*Mathf.Pow(currentWave, 3) + 0.074032f*Mathf.Pow(currentWave, 2) + 0.0718199f*currentWave + 14.738699f;
            zombiesPerWave = Mathf.CeilToInt(zombiesCalculation);
        }
        else if (currentPlayers == 2)
        {
            zombiesCalculation = 0.000054f * Mathf.Pow(currentWave, 3) + 0.169717f * Mathf.Pow(currentWave, 2) + 0.541627f * currentWave + 15.917041f;
            zombiesPerWave = Mathf.CeilToInt(zombiesCalculation);
        }
        else if (currentPlayers == 3)
        {
            zombiesCalculation = 0.000169f * Mathf.Pow(currentWave, 3) + 0.238079f * Mathf.Pow(currentWave, 2) + 1.307276f * currentWave + 21.291046f;
            zombiesPerWave = Mathf.CeilToInt(zombiesCalculation);
        }
        else if (currentPlayers == 4)
        {
            zombiesCalculation = 0.000225f * Mathf.Pow(currentWave, 3) + 0.314314f * Mathf.Pow(currentWave, 2) + 1.835712f * currentWave + 27.596132f;
            zombiesPerWave = Mathf.CeilToInt(zombiesCalculation);
        }
    }

    public void Update()
    {
        
    }

    public void LateUpdate()
    {
        // Entire sections spawns one zombie at between waves because if this is not here the entire code breaks
        if (currentZombies <= 0)
        {
            zombiesSpawned = 0;
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            GameObject newZombie = Instantiate(gameobject, spawnPoints[spawnIndex].transform.position, Quaternion.identity);
            newZombie.GetComponent<EnemyController2>().InitializeEnemy();
            currentZombies++;
            zombiesSpawned++;
            Invoke("NewWave", 10);
        }
    }

    public void NewWave()
    {
        // add a wave and restart the zombie spawning
        currentWave = currentWave + 1;
        SpawnCoroutine = StartCoroutine(SpawnWave());
    }

    public IEnumerator SpawnWave()
    {
        // set health for this wave as well as calculate how many zombies will spawn in this wave
        Health();

        // stopping the coroutine after the max zombies for that wave has been hit
        if (zombiesSpawned >= zombiesPerWave)
        {
            StopCoroutine(SpawnWave());
            yield return null;
        } 
        
        // actually spawning the zombie
        int zombiesToSpawn = zombiesPerWave - zombiesSpawned;

        for (int i = 0; i < zombiesToSpawn ; i++) 
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            GameObject newZombie = Instantiate(gameobject, spawnPoints[spawnIndex].transform.position, Quaternion.identity);
            newZombie.GetComponent<EnemyController2>().InitializeEnemy();
            currentZombies++;
            zombiesSpawned++;
            yield return new WaitForSeconds(2);
        }

        // going through this again after ever zombie that is spawned
        Invoke("SpawnWave", spawnDelay);
    }

    public void Health()
    {
        // calculate health per wave
        if (currentWave <= 9)
        {
            currentZombieHealth = 150 + 100 * (currentWave - 1);
        }
        else
        {
            currentZombieHealth = 950;
            currentZombieHealth = Mathf.Pow(currentZombieHealth, currentWave);
        }
    }
}
