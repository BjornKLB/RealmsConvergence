using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int healthPlayer;
    public int maxHealth;

    public float timer;
    public float timerDuration;
    public float reviveTimer;
    public float reviveTimerDuration;

    public bool dead;
    public bool downed;
    public bool healthDecreased;

    public TextMeshProUGUI healthUI;

    void Start()
    {
        maxHealth = 150;
        healthPlayer = maxHealth;
        dead = false;
        timerDuration = 6f;
        reviveTimerDuration = 5f;
    }

    void Update()
    {
        // Regenerate health
        if (healthDecreased)
        {
            timer += Time.deltaTime;

            if (timer >= timerDuration)
            {
                healthDecreased = false;
                timer = 0f;
                healthPlayer = maxHealth;
            }
        }

        // Revive yourself
        if (downed)
        {
            reviveTimer = Time.deltaTime;

            if (reviveTimer >= reviveTimerDuration)
            {
                downed = false;
                reviveTimer = 0f;
                healthPlayer = maxHealth;
            }
        }

        // End game if player dies
        if (dead == true && !GameObject.Find("ReviveMachine").GetComponent<ReviveController>().reviveObtained && !downed)
        {
            Debug.Log("Dead");
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }

        if (dead == true && GameObject.Find("ReviveMachine").GetComponent<ReviveController>().reviveObtained)
        {
            downed = true;
            dead = false;
            GameObject.Find("PerkController").GetComponent<PerkController>().perkTotal = 0;
        }

        if (healthPlayer <= 0)
        {
            dead = true;
        }


        // Showcase health on UI
        healthUI.text = healthPlayer.ToString();


        // Increase max health based on Juggernog
        if (GameObject.Find("JugMachine").GetComponent<JugController>().jugObtained)
        {
            maxHealth = 250;
            
            if (!healthDecreased)
            {
                healthPlayer = maxHealth;
            }
        }
        else
        {
            maxHealth = 150;
        }
    }

    public void AddToHealth(int value)
    {
        healthPlayer += value;
    }

    public void RemoveFromHealth(int value)
    {
        healthPlayer -= value;
    }


}
