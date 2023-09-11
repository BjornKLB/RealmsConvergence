using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class InteractionBehaviour : MonoBehaviour
{
    public float interactionRange;

    public TextMeshProUGUI hintDialogue;

    public Transform interactionSource;


    void Start()
    {
        
    }


    void Update()
    {
        
            Ray r = new Ray(interactionSource.position, interactionSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, interactionRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }

                else
                {
                    hintDialogue.text = "";
                }
            }
    }
}
