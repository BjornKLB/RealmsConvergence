using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTo : MonoBehaviour
{
    public float timerDuration;
    public float timer;

    public Vector3 runTo;

    public Transform goal;
    public Transform distraction;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        timerDuration = 5f;
    }

    void Update()
    {
        goal = GameObject.Find("John").transform;
        runTo = transform.position + (transform.position - goal.position);

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

        if (GameObject.Find("John").GetComponent<PlayerHealth>().downed)
        {
            timer += Time.deltaTime;
            agent.destination = distraction.position;

            if (timer >= timerDuration)
            {
                agent.destination = goal.position;
                GameObject.Find("John").GetComponent<PlayerHealth>().downed = false;
                timer = 0;
            }
        }
    }
}