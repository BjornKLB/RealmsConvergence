using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private bool isBurning;
    private bool isFrozen;
    private bool isStunned;

    public float attackRange = 2f;
    public int attackDamage = 10;
    public float spawnDelay = 3f;
    public int zombiesPerWave = 5;
    public int maxZombies = 8;
    public GameObject[] spawnPoints;

    public NavMeshAgent agent;
    public Transform player;
    //public Animator animator;
    private bool isDead = false;
    private int currentZombies = 0;
    private int zombiesSpawned = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();

        SpawnWave();
    }

    private void Update()
    {
        if (!isDead)
        {
            agent.SetDestination(player.position);
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= attackRange)
            {
                AttackPlayer();
            }
            else
            {
                //animator.SetBool("IsAttacking", false);
            }
        }
    }

    private void SpawnWave()
    {
        if (zombiesSpawned >= zombiesPerWave)
            return;

        int zombiesToSpawn = Mathf.Min(zombiesPerWave - zombiesSpawned, maxZombies - currentZombies);

        for (int i = 0; i < zombiesToSpawn; i++)
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            GameObject newZombie = Instantiate(gameObject, spawnPoints[spawnIndex].transform.position, Quaternion.identity);
            newZombie.GetComponent<EnemyController>().InitializeEnemy();
            currentZombies++;
            zombiesSpawned++;
        }

        Invoke("SpawnWave", spawnDelay);
    }

    private void InitializeEnemy()
    {
        agent.enabled = true;
        //animator.enabled = true;
        //animator.SetBool("IsRunning", true);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        // Play attack animation
        //animator.SetBool("IsAttacking", true);

        // Deal damage to the player (you can implement this part separately)
        // player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    }

    public void Die()
    {
        isDead = true;
        // Play death animation
        //animator.SetTrigger("Die");

        // Disable components to prevent further actions
        agent.enabled = false;
        //animator.enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

        currentZombies--;

        // Destroy the GameObject after a certain time
        Destroy(gameObject, 5f);
    }

    public void ApplyFireEffect()
    {
        if (!isBurning)
        {
            // Apply fire effect to the enemy
            isBurning = true;
            // TODO: Implement burning damage over time
        }
    }

    public void ApplyIceEffect()
    {
        if (!isFrozen)
        {
            // Apply ice effect to the enemy
            isFrozen = true;
            // TODO: Implement freezing effect and slow movement speed
        }
    }

    public void ApplyElectricEffect()
    {
        if (!isStunned)
        {
            // Apply electric effect to the enemy
            isStunned = true;
            // TODO: Implement stunning effect and interrupt enemy actions
        }
    }

    public void ApplyWindEffect()
    {
        // TODO: Implement disorienting effect and knockback/pushback
    }
}