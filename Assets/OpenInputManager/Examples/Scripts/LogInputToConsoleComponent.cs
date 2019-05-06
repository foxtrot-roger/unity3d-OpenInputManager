using OpenInputManager;
using System.Linq;
using UnityEngine;

public class LogInputToConsoleComponent : MonoBehaviour
{
    InputSettingsDisplayComponent InputSettingsDisplayComponent;

    void Start()
    {
        InputSettingsDisplayComponent = GetComponent<InputSettingsDisplayComponent>();
    }

    void Update()
    {
        var settings = InputSettingsDisplayComponent?.InputManagerSettings?.Axes ?? Enumerable.Empty<InputSettings>();
        foreach (var input in settings)
        {
            if (input.AxisType == AxisType.JoystickAxis)
                ShowAxis(input);

            else if (input.AxisType == AxisType.KeyOrMouseButton)
                ShowButton(input);
        }
    }

    void ShowButton(InputSettings axisConfig)
    {
        try
        {
            if (Input.GetButton(axisConfig.Name))
                Debug.Log("Axis : " + axisConfig.Name);
        }
        catch (System.Exception)
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
        catch (System.Exception)
        {

        }
    }
}
