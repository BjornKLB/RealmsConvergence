using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeadshotController : MonoBehaviour, IInteractable
{
    public bool deadshotObtained = false;

    public TextMeshProUGUI hintDialogue;

    public PointsController PointReference;
    public PerkController PerkReference;

    public void Interact()
    {
        if (!deadshotObtained)
        {
            hintDialogue.text = "Press F to buy Deadshot for 2000.";
        }
        else if (deadshotObtained)
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


        if ((GameObject.Find("PointsController").GetComponent<PointsController>().pointsTotal >= 2000) && (!deadshotObtained) && Input.GetKeyDown(KeyCode.F) && (GameObject.Find("Power").GetComponent<PowerController>().powerOn) && (GameObject.Find("PerkController").GetComponent<PerkController>().perkTotal < GameObject.Find("PerkController").GetComponent<PerkController>().perkMax))
        {
            PerkReference.AddToPerks(1);
            PointReference.RemoveFromPoints(2000);
            deadshotObtained = true;
        }

        if (GameObject.Find("PerkController").GetComponent<PerkController>().perkTotal == 0)
        {
            deadshotObtained = false;
        }
    }
}
