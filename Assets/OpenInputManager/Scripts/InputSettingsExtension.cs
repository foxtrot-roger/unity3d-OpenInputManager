using System;
using System.Collections.Generic;

namespace OpenInputManager
{
    public static class InputSettingsExtension
    {
        public static InputSettings Configure(this InputSettings inputSettings,
            string name = null,
            string descriptiveName = null,
            string descriptiveNegativeName = null,
            string negativeButton = null,
            string positiveButton = null,
            string altNegativeButton = null,
            string altPositiveButton = null,
            float? gravity = null,
            float? dead = null,
            float? sensitivity = null,
            bool? snap = null,
            bool? invert = null,
            AxisType? axisType = null,
            AxisNumber? axisNumber = null,
            JoystickNumber? joystickNumber = null)
        {
            inputSettings.Name = name ?? inputSettings.Name;
            inputSettings.DescriptiveName = descriptiveName ?? inputSettings.DescriptiveName;
            inputSettings.DescriptiveNegativeName = descriptiveNegativeName ?? inputSettings.DescriptiveNegativeName;

            inputSettings.NegativeButton = negativeButton ?? inputSettings.NegativeButton;
            inputSettings.PositiveButton = positiveButton ?? inputSettings.PositiveButton;
            inputSettings.AltNegativeButton = altNegativeButton ?? inputSettings.AltNegativeButton;
            inputSettings.AltPositiveButton = altPositiveButton ?? inputSettings.AltPositiveButton;

            inputSettings.Gravity = gravity ?? inputSettings.Gravity;
            inputSettings.Dead = dead ?? inputSettings.Dead;
            inputSettings.Sensitivity = sensitivity ?? inputSettings.Sensitivity;
            inputSettings.Snap = snap ?? inputSettings.Snap;
            inputSettings.Invert = invert ?? inputSettings.Invert;

            inputSettings.AxisType = axisType ?? inputSettings.AxisType;
            inputSettings.AxisNumber = axisNumber ?? inputSettings.AxisNumber;
            inputSettings.JoystickNumber = joystickNumber ?? inputSettings.JoystickNumber;

            return inputSettings;
        }

        public static InputSettings ConfigureInfo(
            this InputSettings inputSettings,
            string name,
            string descriptiveName = null,
            string descriptiveNegativeName = null)
        {
            return inputSettings.Configure(
                name: name,
                descriptiveName: descriptiveName,
                descriptiveNegativeName: descriptiveNegativeName);
        }

        public static InputSettings ConfigureButton(
            this InputSettings inputSettings,
            string positiveButton,
            string altPositiveButton = null)
        {
            return inputSettings.TypeIsKeyOrMouseButton()
                .SetPositiveButton(positiveButton)
                .SetAltPositiveButton(altPositiveButton);
        }
        public static InputSettings ConfigureButton(
            this InputSettings inputSettings,
            JoystickNumber joystickNumber,
            JoystickButtonNumber positiveJoystickButton,
            JoystickButtonNumber? altPositiveJoystickButton = null)
        {
            return inputSettings
                .TypeIsKeyOrMouseButton()
                .SetPositiveButton(joystickNumber, positiveJoystickButton)
                .SetAltPositiveButton(joystickNumber, altPositiveJoystickButton);
        }
        public static InputSettings ConfigureButton(
            this InputSettings inputSettings,
            MouseButtonNumber positiveButton,
            MouseButtonNumber? altPositiveButton = null)
        {
            return inputSettings.TypeIsKeyOrMouseButton()
                .SetPositiveButton(positiveButton)
                .SetAltPositiveButton(altPositiveButton);
        }

        public static InputSettings ConfigureButtonAxis(
            this InputSettings inputSettings,
            string positiveButton,
            string negativeButton,
            string altPositiveButton = null,
            string altNegativeButton = null)
        {
            return inputSettings.TypeIsKeyOrMouseButton()
                .SetPositiveButton(positiveButton)
                .SetAltPositiveButton(altPositiveButton)
                .SetNegativeButton(negativeButton)
                .SetAltNegativeButton(altNegativeButton);
        }
        public static InputSettings ConfigureButtonAxis(
            this InputSettings inputSettings,
            JoystickNumber joystickNumber,
            JoystickButtonNumber positiveButton,
            JoystickButtonNumber negativeButton,
            JoystickButtonNumber? altPositiveButton = null,
            JoystickButtonNumber? altNegativeButton = null)
        {
            return inputSettings.TypeIsKeyOrMouseButton()
                .SetPositiveButton(joystickNumber, positiveButton)
                .SetAltPositiveButton(joystickNumber, altPositiveButton)
                .SetNegativeButton(joystickNumber, negativeButton)
                .SetAltNegativeButton(joystickNumber, altNegativeButton);
        }
        public static InputSettings ConfigureButtonAxis(
            this InputSettings inputSettings,
            MouseButtonNumber positiveButton,
            MouseButtonNumber negativeButton,
            MouseButtonNumber? altPositiveButton = null,
            MouseButtonNumber? altNegativeButton = null)
        {
            return inputSettings.TypeIsKeyOrMouseButton()
                .SetPositiveButton(positiveButton)
                .SetAltPositiveButton(altPositiveButton)
                .SetNegativeButton(negativeButton)
                .SetAltNegativeButton(altNegativeButton);
        }

        public static InputSettings ConfigureMouseMovement(
            this InputSettings inputSettings,
            AxisNumber axisNumber)
        {
            return inputSettings.TypeIsMouseMovement(axisNumber);
        }

        public static InputSettings ConfigureJoystickAxis(
            this InputSettings inputSettings,
            JoystickNumber joystickNumber,
            AxisNumber axisNumber)
        {
            return inputSettings
                .TypeIsJoystickAxis(joystickNumber, axisNumber);
        }

        public static InputSettings ConfigureJoystickButtonAxis(
            this InputSettings inputSettings,
            JoystickNumber joystickNumber,
            JoystickButtonNumber positiveJoystickButton,
            JoystickButtonNumber negativeJoystickButton,
            JoystickButtonNumber? altNegativeJoystickButton = null,
            JoystickButtonNumber? altPositiveJoystickButton = null)
        {
            return inputSettings
                .TypeIsKeyOrMouseButton()
                .SetPositiveButton(joystickNumber, positiveJoystickButton)
                .SetNegativeButton(joystickNumber, negativeJoystickButton)
                .SetAltNegativeButton(joystickNumber, altNegativeJoystickButton)
                .SetAltPositiveButton(joystickNumber, altPositiveJoystickButton);
        }

        public static InputSettings TypeIsKeyOrMouseButton(
            this InputSettings inputSettings)
        {
            return inputSettings.Configure(
                axisType: AxisType.KeyOrMouseButton,
                axisNumber: AxisNumber.AxisX,
                joystickNumber: JoystickNumber.AllJoysticks);
        }
        public static InputSettings TypeIsJoystickAxis(
            this InputSettings inputSettings,
            JoystickNumber joystickNumber,
            AxisNumber axisNumber)
        {
            return inputSettings.Configure(
                axisType: AxisType.JoystickAxis,
                joystickNumber: joystickNumber,
                axisNumber: axisNumber);
        }
        public static InputSettings TypeIsMouseMovement(
            this InputSettings inputSettings,
            AxisNumber axisNumber)
        {
            return inputSettings.Configure(
                axisType: AxisType.MouseMovement,
                joystickNumber: JoystickNumber.AllJoysticks,
                axisNumber: axisNumber);
        }

        public static InputSettings SetPositiveButton(
            this InputSettings inputSettings,
            string positiveButton)
        {
            return inputSettings.Configure(positiveButton: positiveButton);
        }
        public static InputSettings SetPositiveButton(
            this InputSettings inputSettings,
            JoystickNumber joystickNumber,
            JoystickButtonNumber? joystickButtonNumber)
        {
            return inputSettings
                .SetPositiveButton(UnityFormat.JoystickButtonName(joystickNumber, joystickButtonNumber));
        }
        public static InputSettings SetPositiveButton(
            this InputSettings inputSettings,
            MouseButtonNumber? mouseButtonNumber)
        {
            return inputSettings.SetPositiveButton(UnityFormat.MouseButtonName(mouseButtonNumber));
        }

        public static InputSettings SetAltPositiveButton(
            this InputSettings inputSettings,
            string positiveButton)
        {
            return inputSettings.Configure(altPositiveButton: positiveButton);
        }
        public static InputSettings SetAltPositiveButton(
            this InputSettings inputSettings,
            JoystickNumber joystickNumber,
            JoystickButtonNumber? joystickButtonNumber)
        {
            return inputSettings
                .SetAltPositiveButton(UnityFormat.JoystickButtonName(joystickNumber, joystickButtonNumber));
        }
        public static InputSettings SetAltPositiveButton(
            this InputSettings inputSettings,
            MouseButtonNumber? mouseButtonNumber)
        {
            return inputSettings.SetAltPositiveButton(UnityFormat.MouseButtonName(mouseButtonNumber));
        }

        public static InputSettings SetNegativeButton(
            this InputSettings inputSettings,
            string negativeButton)
        {
            return inputSettings.Configure(negativeButton: negativeButton);
        }
        public static InputSettings SetNegativeButton(
            this InputSettings inputSettings,
            JoystickNumber joystickNumber,
            JoystickButtonNumber? joystickButtonNumber)
        {
            return inputSettings
                .SetNegativeButton(UnityFormat.JoystickButtonName(joystickNumber, joystickButtonNumber));
        }
        public static InputSettings SetNegativeButton(
            this InputSettings inputSettings,
            MouseButtonNumber? mouseButtonNumber)
        {
            return inputSettings.SetNegativeButton(UnityFormat.MouseButtonName(mouseButtonNumber));
        }

        public static InputSettings SetAltNegativeButton(
            this InputSettings inputSettings,
            string negativeButton)
        {
            return inputSettings.Configure(altNegativeButton: negativeButton);
        }
        public static InputSettings SetAltNegativeButton(
            this InputSettings inputSettings,
            JoystickNumber joystickNumber,
            JoystickButtonNumber? joystickButtonNumber)
        {
            return inputSettings
                .SetAltNegativeButton(UnityFormat.JoystickButtonName(joystickNumber, joystickButtonNumber));
        }
        public static InputSettings SetAltNegativeButton(
            this InputSettings inputSettings,
            MouseButtonNumber? mouseButtonNumber)
        {
            return inputSettings.SetAltNegativeButton(UnityFormat.MouseButtonName(mouseButtonNumber));
        }


        [Obsolete]
        public static InputSettings FindByName(this List<InputSettings> axes, string axisName)
        {
            if (axes == null)
                return null;
            else
                return axes.Find(o => o.Name == axisName);
        }
        [Obsolete]
        public static InputSettings GetOrCreate(this List<InputSettings> axes, string axisName)
        {
            var axis = axes.FindByName(axisName);
            if (axis == null)
            {
                axis = new InputSettings { Name = axisName };
                axes.Add(axis);
            }

            return axis;
        }
    }
}
