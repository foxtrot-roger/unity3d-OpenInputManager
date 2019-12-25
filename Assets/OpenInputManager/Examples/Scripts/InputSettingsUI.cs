using OpenInputManager;
using System;
using UnityEngine;
using UnityEngine.UI;

public class InputSettingsUI : MonoBehaviour
{
    public InputConfiguration InputSettings;
    public Text NameText;
    public Text StateText;
    Action<InputConfiguration> UpdateUI;

    public void SetModel(InputConfiguration inputConfiguration)
    {
        InputSettings = inputConfiguration;
        NameText.text = inputConfiguration.Name;
        switch (inputConfiguration.AxisType)
        {
            case AxisType.KeyOrMouseButton:
                if (string.IsNullOrEmpty(inputConfiguration.NegativeButton))
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

    void DisplayButtonState(InputConfiguration inputConfiguration)
    {
        StateText.text = Input.GetButton(inputConfiguration.Name)
            ? "[x]"
            : "[ ]";
    }
    void DisplayAxisState(InputConfiguration inputConfiguration)
    {
        var input = Input.GetAxis(inputConfiguration.Name);
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
