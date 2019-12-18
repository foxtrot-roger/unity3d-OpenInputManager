using OpenInputManager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSettingsUI : MonoBehaviour
{
    public InputConfiguration InputSettings;
    public Text NameText;
    public Text StateText;
    Action<InputConfiguration> UpdateUI;

    public void SetModel(InputConfiguration inputSettings)
    {
        InputSettings = inputSettings;
        NameText.text = inputSettings.Name;
        switch (inputSettings.AxisType)
        {
            case AxisType.KeyOrMouseButton:
                if (string.IsNullOrEmpty(inputSettings.NegativeButton))
                    UpdateUI = DisplayButtonState;
                else
                    UpdateUI = DisplayAxisState;
                break;
            case AxisType.MouseMovement:
                UpdateUI = DisplayAxisState;
                break;
            case AxisType.JoystickAxis:
                UpdateUI = DisplayAxisState;
                break;
            default:
                break;
        }
    }

    void DisplayButtonState(InputConfiguration inputSettings)
    {
        StateText.text = Input.GetButton(inputSettings.Name)
            ? "[x]"
            : "[ ]";
    }
    void DisplayAxisState(InputConfiguration inputSettings)
    {
        var input = Input.GetAxis(inputSettings.Name);
        if (input < 0)
            StateText.text = "[-]";
        else if (input == 0)
            StateText.text = "[ ]";
        else
            StateText.text = "[+]";
    }

    void Update()
    {
        if (UpdateUI != null)
            UpdateUI(InputSettings);
    }
}
