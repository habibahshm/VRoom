using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberPad : MonoBehaviour
{

    [SerializeField] private GameObject keyCard;
    private string correctCode = "1442";
    private string enterededcode;
    public TextMeshProUGUI debugScreen;
    public TextMeshProUGUI codeScreen;
    private int intialLen;
    

    protected void Awake()
    {
        intialLen = codeScreen.text.Length;
    }

    public void enterCode(int num)
    {
        if (codeScreen.text.Length < intialLen + 4)
        {
            codeScreen.SetText(codeScreen.text + num);
            enterededcode += num.ToString();
        }
        
        if(codeScreen.text.Length == intialLen + 4)
        {
            debugScreen.SetText("eqal");
            if(enterededcode == correctCode)
            {
                keyCard.SetActive(true);
            }
            else
            {
                codeScreen.SetText("Code Input: ");
            }
            enterededcode = "";
        }
            
    }
}
