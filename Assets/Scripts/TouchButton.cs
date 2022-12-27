using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class TouchButton : XRBaseInteractable
{
    private ChangeMaterial changeMaterial;
    public TextMeshProUGUI codeScreen;
    public TextMeshProUGUI debugScreen;
    [SerializeField] private int num;
    private int intialLen;

    protected override void Awake()
    {
        base.Awake();
        changeMaterial = GetComponent<ChangeMaterial>();
        intialLen = codeScreen.text.Length;
    }
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        changeMaterial.ToggleMaterial();
        if(codeScreen.text.Length < intialLen+4)
            codeScreen.SetText(codeScreen.text + num);
       
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        changeMaterial.ToggleMaterial();
    }
}
