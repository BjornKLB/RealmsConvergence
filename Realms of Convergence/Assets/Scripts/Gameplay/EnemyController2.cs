using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController2 : MonoBehaviour
{
    // Variables sorted based on type
    public float attackRange = 5f;
    public float health;
    public float CurrentWave;
    public float distance;
    public float timerDuration;
    public float timer;
    public float ignoreTimerDuration;
    public float ignoreTimer;

    public int attackDamage = 10;
    public int damping = 1;
    public float speed;

    public bool isDead = false;

    public Transform player;

    public PlayerHealth HealthReference;

    public NavMeshAgent agent;

    public void Start()
    {
        //set the speed for the pathfinding
        agent.speed = speed;
        // Find the target and set health
        player = GameObject.Find("John").transform;
        Health();
        timerDuration = 0.5f;
    }

    public void Update()
    {
        if (!isDead)
        {
            distance = Vector3.Distance(transform.position, player.position);

            if (distance <= attackRange && !GameObject.Find("GameController").GetComponent<GameController>().player1Attacked)
            {
                timer += Time.deltaTime;
                agent.speed = 0;

                if (timer >= timerDuration)
                {
                    Invoke("AttackPlayer", 0.5f);
                    GameObject.Find("GameController").GetComponent<GameController>().player1Attacked = true;

                    timer = 0;
                }
                
            }
            else
            {
                timer = 0;
                agent.speed = speed;
            }

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
            health = health*1.1f;
        }
    }

    public void InitializeEnemy()
    {
        // Room for animations
    }

    public void AttackPlayer()
    {
        transform.LookAt(player);
        HealthReference.RemoveFromHealth(50);
        GameObject.Find("GameController").GetComponent<GameController>().player1Attacked = false;
        GameObject.Find("John").GetComponent<PlayerHealth>().healthDecreased = true;
        Debug.Log("bonk");
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