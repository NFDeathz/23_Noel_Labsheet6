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
    public Toggle RinggitToggle;
    public Toggle TaiwanToggle;

    public Text DebugText;

    private const float USD_SGD = 0.76f;
    private const float JPY_SGD = 97.02f;
    private const float MYR_SGD = 3.27f;
    private const float TWD_SGD = 22.96f;

    private float InputValue;
    private float ConvertedValue;

    private bool toggleUpdating = false;

    // Start is called before the first frame update
    void Start()
    {
        USDToggle.isOn = true;
        JPYToggle.isOn = false;
        RinggitToggle.isOn = false;
        TaiwanToggle.isOn = false;
    }

    public void ConvertBtn()
    {
        try
        {
            InputValue = float.Parse(AmountInputField.text);

            if (USDToggle.isOn == true)
            {
                ConvertedValue = InputValue * USD_SGD;
                ValueInputField.text = "" + ConvertedValue + " USD";
            }
            else if (JPYToggle.isOn == true)
            {
                ConvertedValue = InputValue * JPY_SGD;
                ValueInputField.text = "" + ConvertedValue + " JPY";
            }
            else if (RinggitToggle.isOn == true)
            {
                ConvertedValue = InputValue * MYR_SGD;
                ValueInputField.text = "" + ConvertedValue + " MYR";
            }
            else if (TaiwanToggle.isOn == true)
            {
                ConvertedValue = InputValue * TWD_SGD;
                ValueInputField.text = "" + ConvertedValue + " TWD";
            }
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
        USDToggle.isOn = true;
        JPYToggle.isOn = false;
        RinggitToggle.isOn = false;
        TaiwanToggle.isOn = false;
        DebugText.text = "Debugging";
    }

    public void toggleUpdate(GameObject thisToggle)
    {
        if (toggleUpdating == true)
        {
            return;
        }

        toggleUpdating = true;

        USDToggle.isOn = false;
        JPYToggle.isOn = false;
        RinggitToggle.isOn = false;
        TaiwanToggle.isOn = false;

        thisToggle.GetComponent<Toggle>().isOn = true;

        toggleUpdating = false;
    }
}
