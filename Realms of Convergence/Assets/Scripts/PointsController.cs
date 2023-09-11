using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    public int playersTotal;

    public GameObject pointsPlayer1;
    public GameObject pointsPlayer2;
    public GameObject pointsPlayer3;
    public GameObject pointsPlayer4;

    void Start()
    {
        //playersTotal = GameObject.Find("SpawnController").GetComponent<SpawnController>().currentPlayers;
        playersTotal = 4;

        if (playersTotal == 1)
        {
            pointsPlayer2.SetActive(false);
            pointsPlayer3.SetActive(false);
            pointsPlayer4.SetActive(false);
        }

        if (playersTotal == 2)
        {
            pointsPlayer3.SetActive(false);
            pointsPlayer4.SetActive(false);
        }

        if (playersTotal == 3)
        {
            pointsPlayer4.SetActive(false);
        }
    }

    void Update()
    {
        
    }
}
