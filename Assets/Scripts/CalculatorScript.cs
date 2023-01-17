using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorScript : MonoBehaviour
{
    public InputField AmountInputField;
    public InputField ValueInputField;

    public Toggle USDToggle;
    public Toggle JPYToggle;

    public Text DebugText;

    private const float USD_SGD = 0.76f;
    private const float JPY_SGD = 97.02f;
    
    private float InputValue;
    private float ConvertedValue;

    //----------------
    //Lizhengyuan code
    [SerializeField] private Toggle RMBToggle;
    [SerializeField] private Toggle WONToggle;

    private const float RMB_SGD = 5.11f;
    private const float WON_SGD = 938.16f;

    //---------------------

    // Start is called before the first frame update
    void Start()
    {
        USDToggle.isOn = false;
        JPYToggle.isOn = false;
        //----------------
        //Lizhengyuan code
        RMBToggle.isOn = false;
        WONToggle.isOn = false;

        //---------------------
}

// Update is called once per frame
void Update()
    {
        if (USDToggle.isOn)
        {
            JPYToggle.enabled = false;
        }
        else if (JPYToggle.isOn)
        {
            USDToggle.enabled = false;
        }
        else
        {
            USDToggle.enabled = true;
            JPYToggle.enabled = true;
        }
        //-----------------------------
        //Lizhengyuan code 
        if (RMBToggle.isOn)
        {
            WONToggle.enabled = false;
        }
        else
        {
            WONToggle.enabled = true;
        }

        if (WONToggle.isOn)
        {
            RMBToggle.enabled = false;
        }
        else
        {
            RMBToggle.enabled = true;
        }
        //-----------------------------
    }

    public void ConvertBtn()
    {
        try
        {
            InputValue = float.Parse(AmountInputField.text);

            if (USDToggle.isOn == true)
            {
                ConvertedValue = InputValue * USD_SGD;
                JPYToggle.isOn = false;
                ValueInputField.text = "" + ConvertedValue + " USD";
            }

            if (JPYToggle.isOn == true)
            {
                ConvertedValue = InputValue * JPY_SGD;
                USDToggle.isOn = false;
                ValueInputField.text = "" + ConvertedValue + " JPY";
            }
            //---------------------
            //Lizhengyuan code
            if(RMBToggle.isOn == true)
            {
                ConvertedValue = InputValue * RMB_SGD;
                RMBToggle.isOn = false;
                ValueInputField.text = ConvertedValue + " RMB";
            }
            if(WONToggle.isOn == true)
            {
                ConvertedValue = InputValue * WON_SGD;
                WONToggle.isOn = false;
                ValueInputField.text = ConvertedValue + " WON";
            }

            //---------------------
        }
        catch
        {
            DebugText.text = "Please enter a valid amount.";
        }
    }

    public void ClearBtn()
    {
        AmountInputField.text = "";
        ValueInputField.text = "";
        USDToggle.isOn = false;
        JPYToggle.isOn = false;
        DebugText.text = "Debugging";

        //--------------------------
        //Lizhengyuan code
        RMBToggle.enabled = true;
        RMBToggle.isOn = false;
        WONToggle.enabled = true;
        WONToggle.isOn = false;

        //--------------------------
    }
}
