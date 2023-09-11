using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerController : MonoBehaviour, IInteractable
{
    public bool powerOn = false;

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            powerOn = true;
        }
    }
}