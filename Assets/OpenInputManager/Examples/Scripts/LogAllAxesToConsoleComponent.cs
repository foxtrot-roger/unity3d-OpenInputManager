using OpenInputManager;
using System;
using UnityEngine;

public class LogAllAxesToConsoleComponent : MonoBehaviour
{
    public InputManagerSettings InputManagerSettings;

    void OnEnable()
    {
        InputManagerSettings = InputManager.LoadFromProjectSettings();
        InputManager.OnSettingsSaved += UpdateSettings;
    }

    void OnDisable()
    {
        InputManager.OnSettingsSaved -= UpdateSettings;
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
            }
        }
    }

    void UpdateSettings(string settingsAssetPath, InputManagerSettings newSettings)
    {
        InputManagerSettings = newSettings;
    }

    static void ShowButton(InputSettings axisConfig)
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
    static void ShowAxis(InputSettings axisConfig)
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
}
