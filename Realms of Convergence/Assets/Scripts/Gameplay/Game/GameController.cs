using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int playerTotal;
    public int perkMax;
    public int zombieTotal;

    public float timer;
    public float timerDuration;

    public float R;
    public float calculation;

    public bool player1Attacked;
    public bool coldWarActive;
    public bool eggsComplete;
    public bool wonderWeaponActive;
    public bool causeEffectActive;

    public TextMeshProUGUI hintDialogue;

    public GameObject hints;

    void Awake()
    {
        playerTotal = 1;
        player1Attacked = false;
        timerDuration = 0.5f;

        coldWarActive = false;
        eggsComplete = false;
        wonderWeaponActive = false;
        causeEffectActive = false;
    }

    void Start()
    {
        perkMax = 4;

        hints.SetActive(true);
        hintDialogue.text = "";
    }



    void Update()
    {
        R = GameObject.Find("SpawnController").GetComponent<SpawnController>().currentWave;

        // one player
        if (playerTotal == 1)
        {
            if (R == 1) { zombieTotal = 6; }
            if (R == 2) { zombieTotal = 8; }
            if (R == 3) { zombieTotal = 13; }
            if (R == 4) { zombieTotal = 18; }
            if (R == 5) { zombieTotal = 24; }
            if (R == 6) { zombieTotal = 27; }
            if (R == 7) { zombieTotal = 28; }
            if (R == 8) { zombieTotal = 28; }
            if (R == 9) { zombieTotal = 29; }
            if (R == 10) { zombieTotal = 33; }

            if (R > 10)
            {
                calculation = 0.000058f * Mathf.Pow(R, 3) + 0.074032f * Mathf.Pow(R, 2) + 0.071819f * R + 14.738699f;
                zombieTotal = Mathf.CeilToInt(calculation);
            }
        }

        // two players
        if (playerTotal == 2 && R > 10)
        {
            calculation = 0.000054f * Mathf.Pow(R, 3) + 0.169717f * Mathf.Pow(R, 2) + 0.541627f * R + 15.917041f;
            zombieTotal = Mathf.CeilToInt(calculation);
        }

        // three players
        if (playerTotal == 3 && R > 10)
        {
            calculation = 0.000169f * Mathf.Pow(R, 3) + 0.238079f * Mathf.Pow(R, 2) + 1.307276f * R + 21.291056f;
            zombieTotal = Mathf.CeilToInt(calculation);
        }

        // four players
        if (playerTotal == 4 && R > 10)
        {
            calculation = 0.000225f * Mathf.Pow(R, 3) + 0.314314f * Mathf.Pow(R, 2) + 1.835712f * R + 27.596132f;
            zombieTotal = Mathf.CeilToInt(calculation);
        }


        // timer for attacking
        if (player1Attacked)
        {
            timer += Time.deltaTime;

            if (timer >= timerDuration)
            {
                player1Attacked = false;
                timer = 0;
            }
        }
    }
}
