using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReviveController : MonoBehaviour, IInteractable
{
    public bool reviveObtained = false;

    public TextMeshProUGUI hintDialogue;

    public PointsController PointReference;
    public PerkController PerkReference;

    public void Interact()
    {
        if (!reviveObtained)
        {
            hintDialogue.text = "Press F to buy Quick Revive for 500.";
        }
        else if (reviveObtained)
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


        if ((GameObject.Find("PointsController").GetComponent<PointsController>().pointsTotal >= 500) && (!reviveObtained) && Input.GetKeyDown(KeyCode.F) && (GameObject.Find("Power").GetComponent<PowerController>().powerOn) && (GameObject.Find("PerkController").GetComponent<PerkController>().perkTotal < GameObject.Find("PerkController").GetComponent<PerkController>().perkMax))
        {
            PerkReference.AddToPerks(1);
            PointReference.RemoveFromPoints(500);
            reviveObtained = true;
        }
    }
}