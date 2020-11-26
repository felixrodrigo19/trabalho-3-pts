using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class InteractableObject : MonoBehaviour
{
    public Color InteractionColor = Color.red;
    public float MaxDistance = 5f;

    CursorControl CursorControl;
    FirstPersonController FPSController;
    bool isMouseOn;

    private void Start()
    {
        CursorControl = GameObject.Find("GameManager").GetComponent<CursorControl>();
        FPSController = GameObject.Find("FPSController").GetComponent<FirstPersonController>();
    }

    private void OnMouseEnter()
    {
        isMouseOn = true;
        var thisPosition = transform.position;
        var userPosition = FPSController.transform.position;
        var distance = Vector3.Distance(thisPosition, userPosition);

        if (distance <= MaxDistance)
        {
            CursorControl.CursorColor = InteractionColor;
        }
    }

    private void OnMouseExit()
    {
        isMouseOn = false;
    }

    bool IsInInteractionRange
    {
        get
        {
            var thisPosition = transform.position;
            var userPosition = FPSController.transform.position;
            var distance = Vector3.Distance(thisPosition, userPosition);
            return distance <= MaxDistance;
        }
    }

    private void Update()
    {
        if (isMouseOn)
        {
            if (IsInInteractionRange)
            {
                CursorControl.CursorColor = InteractionColor;
            }
            else
            {
                CursorControl.ResetCursor();
            }
        }
    }

    private void OnMouseDown()
    {
        if (IsInInteractionRange)
        {
            BroadcastMessage("OnInteract");
        }
    }
}
