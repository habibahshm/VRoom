using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class CardReader : XRSocketInteractor
{
    private float cardIntialLocation;
    private bool swiping;
    private IXRHoverInteractable interactable;
    private bool validSwipe;
    public TextMeshProUGUI debugScreen;
   

    private void Update()
    {
        if(swiping && interactable != null)
            if (Vector3.Dot(interactable.transform.forward, Vector3.up) < 0.7f)
            {
                validSwipe = false;
            }
       
    }
    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return false;
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        cardIntialLocation = args.interactableObject.transform.position.y;
        swiping = true;
        validSwipe = true;
        interactable = args.interactableObject;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        float cardFinalPos = args.interactableObject.transform.position.y;
        float traveledDist = Mathf.Abs(cardFinalPos - cardIntialLocation);
        if(traveledDist > 0.3f && validSwipe)
        {
            GameObject doorlock = GameObject.Find("DoorPadlock/DoorLockingBar");
            if(doorlock != null)
                doorlock.SetActive(false);
            
        }
    }
}
