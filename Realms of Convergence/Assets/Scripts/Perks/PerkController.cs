using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerkController : MonoBehaviour
{
    public int perkMax;
    public int perkTotal;

    public bool maxPerks;

    public bool deadshotObtained;
    public bool doubleObtained;
    public bool jugObtained;
    public bool muleObtained;
    public bool reviveObtained;
    public bool speedObtained;
    public bool staminObtained;
    public bool whoObtained;
    public bool widowsObtained;

    public bool prevPerkDeadshot;
    public bool prevPerkDouble;
    public bool prevPerkJug;
    public bool prevPerkMule;
    public bool prevPerkRevive;
    public bool prevPerkSpeed;
    public bool prevPerkStamin;
    public bool prevPerkWho;
    public bool prevPerkWidows;

    public TextMeshProUGUI perkCounter;
    public TextMeshProUGUI hintDialogue;

    public GameObject perk1;
    public GameObject perk2;
    public GameObject perk3;
    public GameObject perk4;

    public Texture2D Deadshot;
    public Texture2D Double;
    public Texture2D Juggernog;
    public Texture2D Mule;
    public Texture2D Revive;
    public Texture2D Speed;
    public Texture2D Stamin;
    public Texture2D Who;
    public Texture2D Widows;

    void Start()
    {
        perk1.SetActive(false);
        perk2.SetActive(false);
        perk3.SetActive(false);
        perk4.SetActive(false);
    }


    void Update()
    {
        // get the perk max
        perkMax = GameObject.Find("GameController").GetComponent<GameController>().perkMax;

        // check what perks have been obtained
        deadshotObtained = GameObject.Find("DeadshotMachine").GetComponent<DeadshotController>().deadshotObtained;
        jugObtained = GameObject.Find("JugMachine").GetComponent<JugController>().jugObtained;
        reviveObtained = GameObject.Find("ReviveMachine").GetComponent<ReviveController>().reviveObtained;

        if (perkTotal == 0)
        {
            GameObject.Find("DeadshotMachine").GetComponent<DeadshotController>().deadshotObtained = false;
            GameObject.Find("JugMachine").GetComponent<JugController>().jugObtained = false;
            GameObject.Find("ReviveMachine").GetComponent<ReviveController>().reviveObtained = false;
        }

        // perk counter
        if (perkTotal == 0)
        {
            perkCounter.text = "Total perks: 0";
            perk1.SetActive(false);
            perk2.SetActive(false);
            perk3.SetActive(false);
            perk4.SetActive(false);
        }

        if (perkTotal == 1)
        {
            perkCounter.text = "Total perks: 1";
            perk1.SetActive(true);
            perk2.SetActive(false);
            perk3.SetActive(false);
            perk4.SetActive(false);

            // check for correct perk
            if ((deadshotObtained) && (!prevPerkDeadshot))
            {
                perk1.GetComponent<RawImage>().texture = Deadshot;
                prevPerkDeadshot = true;
            }

            if ((doubleObtained) && (!prevPerkDouble))
            {
                perk1.GetComponent<RawImage>().texture = Double;
                prevPerkDouble = true;
            }

            if ((jugObtained) && (!prevPerkJug))
            {
                perk1.GetComponent<RawImage>().texture = Juggernog;
                prevPerkJug = true;
            }

            if ((muleObtained) && (!prevPerkMule))
            {
                perk1.GetComponent<RawImage>().texture = Mule;
                prevPerkMule = true;
            }

            if ((reviveObtained) && (!prevPerkRevive))
            {
                perk1.GetComponent<RawImage>().texture = Revive;
                prevPerkRevive = true;
            }

            if ((speedObtained) && (!prevPerkSpeed))
            {
                perk1.GetComponent<RawImage>().texture = Speed;
                prevPerkSpeed = true;
            }

            if ((staminObtained) && (!prevPerkStamin))
            {
                perk1.GetComponent<RawImage>().texture = Stamin;
                prevPerkStamin = true;
            }

            if ((whoObtained) && (!prevPerkWho))
            {
                perk1.GetComponent<RawImage>().texture = Who;
                prevPerkWho = true;
            }

            if ((widowsObtained) && (!prevPerkWidows))
            {
                perk1.GetComponent<RawImage>().texture = Widows;
                prevPerkWidows = true;
            }
        }

        if (perkTotal == 2)
        {
            perkCounter.text = "Total perks: 2";
            perk2.SetActive(true);
            perk3.SetActive(false);
            perk4.SetActive(false);

            // check for correct perk
            if ((deadshotObtained) && (!prevPerkDeadshot))
            {
                perk2.GetComponent<RawImage>().texture = Deadshot;
                prevPerkDeadshot = true;
            }

            if ((doubleObtained) && (!prevPerkDouble))
            {
                perk2.GetComponent<RawImage>().texture = Double;
                prevPerkDouble = true;
            }

            if ((jugObtained) && (!prevPerkJug))
            {
                perk2.GetComponent<RawImage>().texture = Juggernog;
                prevPerkJug = true;
            }

            if ((muleObtained) && (!prevPerkMule))
            {
                perk2.GetComponent<RawImage>().texture = Mule;
                prevPerkMule = true;
            }

            if ((reviveObtained) && (!prevPerkRevive))
            {
                perk2.GetComponent<RawImage>().texture = Revive;
                prevPerkRevive = true;
            }

            if ((speedObtained) && (!prevPerkSpeed))
            {
                perk2.GetComponent<RawImage>().texture = Speed;
                prevPerkSpeed = true;
            }

            if ((staminObtained) && (!prevPerkStamin))
            {
                perk2.GetComponent<RawImage>().texture = Stamin;
                prevPerkStamin = true;
            }

            if ((whoObtained) && (!prevPerkWho))
            {
                perk2.GetComponent<RawImage>().texture = Who;
                prevPerkWho = true;
            }

            if ((widowsObtained) && (!prevPerkWidows))
            {
                perk2.GetComponent<RawImage>().texture = Widows;
                prevPerkWidows = true;
            }
        }

        if (perkTotal == 3)
        {
            perkCounter.text = "Total perks: 3";
            perk3.SetActive(true);
            perk4.SetActive(false);

            // check for correct perk
            if ((deadshotObtained) && (!prevPerkDeadshot))
            {
                perk3.GetComponent<RawImage>().texture = Deadshot;
                prevPerkDeadshot = true;
            }

            if ((doubleObtained) && (!prevPerkDouble))
            {
                perk3.GetComponent<RawImage>().texture = Double;
                prevPerkDouble = true;
            }

            if ((jugObtained) && (!prevPerkJug))
            {
                perk3.GetComponent<RawImage>().texture = Juggernog;
                prevPerkJug = true;
            }

            if ((muleObtained) && (!prevPerkMule))
            {
                perk3.GetComponent<RawImage>().texture = Mule;
                prevPerkMule = true;
            }

            if ((reviveObtained) && (!prevPerkRevive))
            {
                perk3.GetComponent<RawImage>().texture = Revive;
                prevPerkRevive = true;
            }

            if ((speedObtained) && (!prevPerkSpeed))
            {
                perk3.GetComponent<RawImage>().texture = Speed;
                prevPerkSpeed = true;
            }

            if ((staminObtained) && (!prevPerkStamin))
            {
                perk3.GetComponent<RawImage>().texture = Stamin;
                prevPerkStamin = true;
            }

            if ((whoObtained) && (!prevPerkWho))
            {
                perk3.GetComponent<RawImage>().texture = Who;
                prevPerkWho = true;
            }

            if ((widowsObtained) && (!prevPerkWidows))
            {
                perk3.GetComponent<RawImage>().texture = Widows;
                prevPerkWidows = true;
            }
        }

        if (perkTotal == 4)
        {
            perkCounter.text = "Total perks: 4";
            perk4.SetActive(true);

            // check for correct perk
            if ((deadshotObtained) && (!prevPerkDeadshot))
            {
                perk4.GetComponent<RawImage>().texture = Deadshot;
                prevPerkDeadshot = true;
            }

            if ((doubleObtained) && (!prevPerkDouble))
            {
                perk4.GetComponent<RawImage>().texture = Double;
                prevPerkDouble = true;
            }

            if ((jugObtained) && (!prevPerkJug))
            {
                perk4.GetComponent<RawImage>().texture = Juggernog;
                prevPerkJug = true;
            }

            if ((muleObtained) && (!prevPerkMule))
            {
                perk4.GetComponent<RawImage>().texture = Mule;
                prevPerkMule = true;
            }

            if ((reviveObtained) && (!prevPerkRevive))
            {
                perk4.GetComponent<RawImage>().texture = Revive;
                prevPerkRevive = true;
            }

            if ((speedObtained) && (!prevPerkSpeed))
            {
                perk4.GetComponent<RawImage>().texture = Speed;
                prevPerkSpeed = true;
            }

            if ((staminObtained) && (!prevPerkStamin))
            {
                perk4.GetComponent<RawImage>().texture = Stamin;
                prevPerkStamin = true;
            }

            if ((whoObtained) && (!prevPerkWho))
            {
                perk4.GetComponent<RawImage>().texture = Who;
                prevPerkWho = true;
            }

            if ((widowsObtained) && (!prevPerkWidows))
            {
                perk4.GetComponent<RawImage>().texture = Widows;
                prevPerkWidows = true;
            }
        }


        // make sure the player can't buy more than the maximum amount of perks
        if (perkTotal < perkMax)
        {
            maxPerks = false;
        }
        else
        {
            maxPerks = true;
        }

        if (maxPerks)
        {

        }
        else
        {

        }

        // gain perks
        if ((Input.GetKeyDown(KeyCode.P)) && (!maxPerks))
        {
            perkTotal++;
        }
    }

    public void AddToPerks(int value)
    {
        perkTotal += value;
    }

    public void RemoveFromPerks(int value)
    {
        perkTotal -= value;
    }
}
