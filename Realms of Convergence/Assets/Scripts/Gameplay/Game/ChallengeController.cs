using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ChallengeController : MonoBehaviour
{
    // BO3 Challenges
    public bool academyBO3;
    public bool buriedBO3;
    public bool castleBO3;
    public bool arenaBO3;
    public bool machineBO3;
    public bool seriousDedicationBO3;

    // CW Challenges
    public bool academyCW;
    public bool buriedCW;
    public bool castleCW;
    public bool arenaCW;
    public bool machineCW;
    public bool seriousDedicationCW;


    // Non-Version Challenges
    public bool mattieRuby;
    public bool mattieWeiss;
    public bool mattieBlake;
    public bool mattieYang;
    public bool mattieTeamRWBY;

    void Update()
    {
        if (!GameObject.Find("GameController").GetComponent<GameController>().coldWarActive)
        {
            // All BO3-based Challenges
            if (academyBO3 && buriedBO3 && castleBO3 && arenaBO3 && machineBO3)
            {
                seriousDedicationBO3 = true;
            }
        }

        else if (GameObject.Find("GameController").GetComponent<GameController>().coldWarActive)
        {
            // All CW-based Challenges
            if (academyCW && buriedCW && castleCW && arenaCW && machineCW)
            {
                seriousDedicationCW = true;
            }
        }

        // All Non-Version Dependant Challenges
        

        if (mattieRuby && mattieWeiss &&  mattieBlake && mattieYang)
        {
            mattieTeamRWBY = true;
        }
    }
}
