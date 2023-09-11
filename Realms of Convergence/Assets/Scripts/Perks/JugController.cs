using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JugController : MonoBehaviour, IInteractable
{    
    public bool jugObtained = false;

    public TextMeshProUGUI hintDialogue;

    public PointsController PointReference;
    public PerkController PerkReference;

    public void Interact()
    {
        if (!jugObtained)
        {
            hintDialogue.text = "Press F to buy Juggernog for 2500.";
        }
        else if (jugObtained)
        {
            hintDialogue.text = "You already have this perk.";
        }

        if (GameObject.Find("PerkController").GetComponent<PerkController>().perkTotal == 4)
        {
            hintDialogue.text = "Perk limit reached.";
        }

        if (!GameObject.Find("Power").GetComponent<PowerController>().powerOn)
        {
            hintDialogue.text = "Must turn on power first.";
        }


        if ((GameObject.Find("PointsController").GetComponent<PointsController>().pointsTotal >= 2500) && (!jugObtained) && Input.GetKeyDown(KeyCode.F) && (GameObject.Find("Power").GetComponent<PowerController>().powerOn) && (GameObject.Find("PerkController").GetComponent<PerkController>().perkTotal < GameObject.Find("PerkController").GetComponent<PerkController>().perkMax))
        {
            PerkReference.AddToPerks(1);
            PointReference.RemoveFromPoints(2500);
            jugObtained = true;
        }

        if (GameObject.Find("PerkController").GetComponent<PerkController>().perkTotal == 0)
        {
            jugObtained = false;
        }
    }
}