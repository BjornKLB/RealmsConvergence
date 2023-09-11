using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour, IIInteractable
{
    public Material Red;
    public Material Blue;
    public Material Green;

   public void Interact()
    {
        if (Input.GetMouseButtonDown(0))
        {
           if (GameObject.Find("ColorsWOOO").GetComponent<ColorController>().selectedRed)
            {
                GetComponent<Renderer>().material = Red;
            }

            if (GameObject.Find("ColorsWOOO").GetComponent<ColorController>().selectedBlue)
            {
                GetComponent<Renderer>().material = Blue;
            }

            if (GameObject.Find("ColorsWOOO").GetComponent<ColorController>().selectedGreen)
            {
                GetComponent<Renderer>().material = Green;
            }
        }
    }
}
