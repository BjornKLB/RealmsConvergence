using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    public int playerTotal;
    public int pointsTotal;

    public TextMeshProUGUI pointPlayer1;
    public TextMeshProUGUI pointPlayer2;
    public TextMeshProUGUI pointPlayer3;
    public TextMeshProUGUI pointPlayer4;

    public GameObject pointsPlayer1;
    public GameObject pointsPlayer2;
    public GameObject pointsPlayer3;
    public GameObject pointsPlayer4;

    void Start()
    {
        playerTotal = GameObject.Find("GameController").GetComponent<GameController>().playerTotal;
        pointsTotal = 50000;

        if (playerTotal == 0)
        {
            playerTotal++;
        }

        if (playerTotal == 1)
        {
            pointsPlayer2.SetActive(false);
            pointsPlayer3.SetActive(false);
            pointsPlayer4.SetActive(false);
        }

        if (playerTotal == 2)
        {
            pointsPlayer3.SetActive(false);
            pointsPlayer4.SetActive(false);
        }

        if (playerTotal == 3)
        {
            pointsPlayer4.SetActive(false);
        }
    }

    void Update()
    {
        pointPlayer1.text = pointsTotal.ToString();
    }

    public void AddToPoints(int value)
    {
        pointsTotal += value;
    }

    public void RemoveFromPoints(int value)
    {
        pointsTotal -= value;
    }
}
