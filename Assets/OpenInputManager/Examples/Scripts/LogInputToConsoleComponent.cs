using OpenInputManager;
using UnityEngine;

public class LogInputToConsoleComponent : MonoBehaviour
{
    public InputManagerConfiguration Configuration;

    void Update()
    {
        foreach (var axisConfig in Configuration.Axes)
        {
            if (axisConfig.AxisType == AxisType.JoystickAxis)
                ShowAxis(axisConfig);

            else if (axisConfig.AxisType == AxisType.KeyOrMouseButton)
                ShowButton(axisConfig);
        }
    }

    void ShowButton(InputInfo axisConfig)
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
    static void ShowAxis(InputInfo axisConfig)
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
