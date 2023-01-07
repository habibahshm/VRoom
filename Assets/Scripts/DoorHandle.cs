using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorHandle : XRBaseInteractable
{
    public TextMeshProUGUI debugScreen;
    public GameObject pullLine;
    public GameObject leftDirection;

    private float max_dragdistance = 0.8f;
    private float door_weight = 20f;
    private bool doorUnlocked = false;

    private GameObject door;

    private Vector3 endPos;
    private Vector3 handleleftdirection;



    private void Start()
    {
        handleleftdirection = transform.right * -1;
        door = GameObject.Find("DoorPadlock");
        endPos = door.transform.position + handleleftdirection * max_dragdistance;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);
        if (doorUnlocked && isSelected)
        {
            
            Vector3 handlePos = transform.position;
            var controllerPos = firstInteractorSelecting.GetAttachTransform(this).position;
            Vector3 pullVector = controllerPos - handlePos;

           /* LineRenderer lineRenderer = pullLine.GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, handlePos);
            lineRenderer.SetPosition(1, controllerPos);

            LineRenderer lineRenderer2 = leftDirection.GetComponent<LineRenderer>();
            lineRenderer2.SetPosition(0, transform.position);
            lineRenderer2.SetPosition(1, transform.TransformPoint(Vector3.left*0.5f));*/


            float dotproduct = Vector3.Dot(pullVector.normalized, handleleftdirection);
            debugScreen.text = dotproduct.ToString();

            if (dotproduct > 0.7f)
               door.transform.position = Vector3.MoveTowards(door.transform.position, endPos, Time.deltaTime*Mathf.Abs(dotproduct)/door_weight);
        
        }

    }
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        GameObject doorlock = GameObject.Find("DoorPadlock/DoorLockingBar");
        if (doorlock == null)
            doorUnlocked = true;
           
            
    }



}
