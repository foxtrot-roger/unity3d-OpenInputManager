using OpenInputManager;
using System;
using UnityEngine;

public class LogAllAxesToConsoleComponent : MonoBehaviour
{
    public InputManager InputManagerSettings;

    void OnEnable()
    {
        InputManagerSettings = InputManager.FromProjectSettings();
    }

    void Update()
    {
        if (InputManagerSettings != null && InputManagerSettings.Axes != null)
        {
            foreach (var input in InputManagerSettings.Axes)
            {
                if (input.AxisType == AxisType.JoystickAxis)
                    ShowAxis(input);

                else if (input.AxisType == AxisType.KeyOrMouseButton)
                    ShowButton(input);

                else if (input.AxisType == AxisType.MouseMovement)
                    ShowMouse(input);
            }
        }
    }

    void UpdateSettings(string settingsAssetPath, InputManager newSettings)
    {
        InputManagerSettings = newSettings;
    }

    static void ShowButton(InputConfiguration axisConfig)
    {
        try
        {
            if (Input.GetButton(axisConfig.Name))
                Debug.Log("Axis : " + axisConfig.Name);
        }
        catch (Exception)
        {

        }
    }
    static void ShowAxis(InputConfiguration axisConfig)
    {
        try
        {
            var value = Input.GetAxis(axisConfig.Name);
            if (value != 0)
                Debug.Log("Button : " + axisConfig.Name);
        }
        catch (Exception)
        {

        }
    }
    static void ShowMouse(InputConfiguration axisConfig)
    {
        try
        {
            var value = Input.GetAxis(axisConfig.Name);
            if (value != 0)
                Debug.Log("Mouse : " + axisConfig.Name);
        }
        catch (Exception)
        {

        }
    }
}
