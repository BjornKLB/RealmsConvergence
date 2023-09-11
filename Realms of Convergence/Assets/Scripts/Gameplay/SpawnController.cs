using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    // Variables sorted based on type
    public float spawnDelay = 3f;
    public float currentZombieHealth;
    public float zombiesCalculation;
    public float currentWave = 0f;
    public int maxZombies = 10;
    public int currentZombies = 0;
    public int zombiesSpawned = 0;
    public int zombiesPerWave;
    public bool Loaded;

    public TextMeshProUGUI waveCounter;

    public GameObject gameobject;
    public GameObject[] spawnPoints;
    public Coroutine SpawnCoroutine;
    public Coroutine NewWaveCoroutine;

    public void Start()
    {
        SpawnCoroutine = StartCoroutine("SpawnWave");
    }

    public void Update()
    {
        waveCounter.text = currentWave.ToString();
        zombiesPerWave = GameObject.Find("GameController").GetComponent<GameController>().zombieTotal;

        if ((currentZombies == 0) && (zombiesSpawned == zombiesPerWave) && (zombiesSpawned != 0))
        {
            SpawnCoroutine = StartCoroutine("NewWave");
            zombiesSpawned = 0;
        }
    }

    public void LateUpdate()
    {
        
    }

    public void NewWave()
    {
        currentWave = currentWave + 1;
        SpawnCoroutine = StartCoroutine(SpawnWave());
    }

    public IEnumerator SpawnWave()
    {
        Health();

        if (zombiesSpawned >= zombiesPerWave)
        {
            StopCoroutine(SpawnWave());
            yield return null;
        } 
        
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

        Invoke("SpawnWave", spawnDelay);
    }

    public void Health()
    {
        if (currentWave <= 9)
        {
            currentZombieHealth = 150 + 100 * (currentWave - 1);
        }
        else
        {
            currentZombieHealth = currentZombieHealth*1.1f;
        }
    }
}
