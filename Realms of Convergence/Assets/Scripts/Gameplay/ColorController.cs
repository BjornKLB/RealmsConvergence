using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorController : MonoBehaviour
{
    public bool selectedRed;
    public bool selectedBlue;
    public bool selectedGreen;
    public bool selectedNone;



    public void Start()
    {
        selectedNone = true;
    }

    public void Red()
    {
        selectedRed = true;
        selectedBlue = false;
        selectedGreen = false;
        selectedNone = false;
    }

    public void Blue()
    {
        selectedRed = false;
        selectedBlue = true;
        selectedGreen = false;
        selectedNone = false;
    }

    public void Green()
    {
        selectedRed = false;
        selectedBlue = false;
        selectedGreen = true;
        selectedNone = false;
    }
}
