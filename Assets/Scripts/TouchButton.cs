using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class TouchButton : XRBaseInteractable
{
    private ChangeMaterial changeMaterial;
    public TextMeshProUGUI debugScreen;
    [SerializeField] private int num;
    private NumberPad numberPadScript;

    protected override void Awake()
    {
        base.Awake();
        changeMaterial = GetComponent<ChangeMaterial>();
        numberPadScript = GameObject.Find("NumberpadScreenDispenser").GetComponent<NumberPad>();
        
    }
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        changeMaterial.ToggleMaterial();
        numberPadScript.enterCode(num);
       
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        changeMaterial.ToggleMaterial();
    }
}
