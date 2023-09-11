using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController2 : MonoBehaviour
{
    // Variables sorted based on type
    public float attackRange = 2f;
    public float health;
    public float CurrentWave;
    public int attackDamage = 10;
    public int damping = 3;
    public int speed;
    public bool isDead = false;

    public Transform player;

    public void Start()
    {
        // Find the target and set health
        player = GameObject.Find("John").transform;
        Health();
    }

    public void Update()
    {
        // Check whether the enemy is still active
        if (!isDead)
        {
            // Calculate distance to player
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= attackRange)
            {
                // Attack player if they are within the attack range
                AttackPlayer();
            }
            else
            {
                // Room for animations
            }

            // Check to see if the enemy needs to be destroyed
            if (health <= 0)
            {
                Die();
            }
        }
    }

    public void Health()
    {
        // Check the current wave to calculate the health based on the wave
        CurrentWave = GameObject.Find("SpawnController").GetComponent<SpawnController>().currentWave;
        if (CurrentWave <= 9)
        {
            health = 150 + 100*(CurrentWave - 1);
        }
        else
        {
            health = 950;
            health = Mathf.Pow(health, CurrentWave);
        }
    }

    public void InitializeEnemy()
    {
        // Room for animations
    }

    public void AttackPlayer()
    {
        // Make sure the enemy is actually facing the player before they attack
        transform.LookAt(player);

        // Room for the actual attack, has not been implemented because I'm currently still testing the spawning behaviour and health scaling of the enemies
    }

    public void Die()
    {
        // deactive the enemy
        isDead = true;

        // remove one enemy from the number of zombies on the map
        GameObject.Find("SpawnController").GetComponent<SpawnController>().currentZombies--;
        
        // kill it with fire
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        Destroy(this.gameObject, 0f);
    }
}