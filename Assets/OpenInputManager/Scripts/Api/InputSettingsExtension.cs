namespace OpenInputManager
{
    public static class InputSettingsExtension
    {
        public static InputConfiguration Configure(this InputConfiguration inputSettings,
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

        public static InputConfiguration ConfigureInfo(
            this InputConfiguration inputSettings,
            string name,
            string descriptiveName = null,
            string descriptiveNegativeName = null)
        {
            return inputSettings.Configure(
                name: name,
                descriptiveName: descriptiveName,
                descriptiveNegativeName: descriptiveNegativeName);
        }

        public static InputConfiguration ConfigureButton(
            this InputConfiguration inputSettings,
            string positiveButton,
            string altPositiveButton = null)
        {
            return inputSettings
                .SetTypeKeyOrMouseButton()
                .SetPositiveButton(positiveButton)
                .SetAltPositiveButton(altPositiveButton);
        }
        public static InputConfiguration ConfigureButton(
            this InputConfiguration inputSettings,
            JoystickNumber joystickNumber,
            JoystickButton positiveJoystickButton,
            JoystickButton? altPositiveJoystickButton = null)
        {
            return inputSettings
                .SetTypeKeyOrMouseButton()
                .SetPositiveButton(joystickNumber, positiveJoystickButton)
                .SetAltPositiveButton(joystickNumber, altPositiveJoystickButton);
        }
        public static InputConfiguration ConfigureButton(
            this InputConfiguration inputSettings,
            MouseButton positiveButton,
            MouseButton? altPositiveButton = null)
        {
            return inputSettings
                .SetTypeKeyOrMouseButton()
                .SetPositiveButton(positiveButton)
                .SetAltPositiveButton(altPositiveButton);
        }

        public static InputConfiguration ConfigureButtonAxis(
            this InputConfiguration inputSettings,
            string negativeButton,
            string positiveButton,
            string altPositiveButton = null,
            string altNegativeButton = null)
        {
            return inputSettings
                .SetTypeKeyOrMouseButton()
                .SetPositiveButton(positiveButton)
                .SetAltPositiveButton(altPositiveButton)
                .SetNegativeButton(negativeButton)
                .SetAltNegativeButton(altNegativeButton);
        }
        public static InputConfiguration ConfigureButtonAxis(
            this InputConfiguration inputSettings,
            JoystickNumber joystickNumber,
            JoystickButton negativeButton,
            JoystickButton positiveButton,
            JoystickButton? altNegativeButton = null,
            JoystickButton? altPositiveButton = null)
        {
            return inputSettings
                .SetTypeKeyOrMouseButton()
                .SetPositiveButton(joystickNumber, positiveButton)
                .SetAltPositiveButton(joystickNumber, altPositiveButton)
                .SetNegativeButton(joystickNumber, negativeButton)
                .SetAltNegativeButton(joystickNumber, altNegativeButton);
        }
        public static InputConfiguration ConfigureButtonAxis(
            this InputConfiguration inputSettings,
            MouseButton negativeButton,
            MouseButton positiveButton,
            MouseButton? altNegativeButton = null,
            MouseButton? altPositiveButton = null)
        {
            return inputSettings
                .SetTypeKeyOrMouseButton()
                .SetPositiveButton(positiveButton)
                .SetAltPositiveButton(altPositiveButton)
                .SetNegativeButton(negativeButton)
                .SetAltNegativeButton(altNegativeButton);
        }

        public static InputConfiguration ConfigureMouseMovement(
            this InputConfiguration inputSettings,
            AxisNumber axisNumber)
        {
            return inputSettings
                .SetTypeMouseMovement(axisNumber);
        }

        public static InputConfiguration ConfigureJoystickAxis(
            this InputConfiguration inputSettings,
            JoystickNumber joystickNumber,
            AxisNumber axisNumber)
        {
            return inputSettings
                .SetTypeJoystickAxis(joystickNumber, axisNumber);
        }

        public static InputConfiguration SetTypeKeyOrMouseButton(
            this InputConfiguration inputSettings)
        {
            return inputSettings.Configure(
                axisType: AxisType.KeyOrMouseButton,
                axisNumber: AxisNumber.AxisX,
                joystickNumber: JoystickNumber.AllJoysticks);
        }
        public static InputConfiguration SetTypeJoystickAxis(
            this InputConfiguration inputSettings,
            JoystickNumber joystickNumber,
            AxisNumber axisNumber)
        {
            return inputSettings.Configure(
                axisType: AxisType.JoystickAxis,
                joystickNumber: joystickNumber,
                axisNumber: axisNumber,
                sensitivity: 1);
        }
        public static InputConfiguration SetTypeMouseMovement(
            this InputConfiguration inputSettings,
            AxisNumber axisNumber)
        {
            return inputSettings.Configure(
                axisType: AxisType.MouseMovement,
                joystickNumber: JoystickNumber.AllJoysticks,
                axisNumber: axisNumber,
                sensitivity: 1);
        }

        public static InputConfiguration SetPositiveButton(
            this InputConfiguration inputSettings,
            string positiveButton)
        {
            return inputSettings
                .Configure(positiveButton: positiveButton);
        }
        public static InputConfiguration SetPositiveButton(
            this InputConfiguration inputSettings,
            JoystickNumber joystickNumber,
            JoystickButton? joystickButtonNumber)
        {
            return inputSettings
                .SetPositiveButton(UnityButtonNameFormat.JoystickButtonName(joystickNumber, joystickButtonNumber));
        }
        public static InputConfiguration SetPositiveButton(
            this InputConfiguration inputSettings,
            MouseButton? mouseButtonNumber)
        {
            return inputSettings
                .SetPositiveButton(UnityButtonNameFormat.MouseButtonName(mouseButtonNumber));
        }

        public static InputConfiguration SetAltPositiveButton(
            this InputConfiguration inputSettings,
            string positiveButton)
        {
            return inputSettings
                .Configure(altPositiveButton: positiveButton);
        }
        public static InputConfiguration SetAltPositiveButton(
            this InputConfiguration inputSettings,
            JoystickNumber joystickNumber,
            JoystickButton? joystickButtonNumber)
        {
            return inputSettings
                .SetAltPositiveButton(UnityButtonNameFormat.JoystickButtonName(joystickNumber, joystickButtonNumber));
        }
        public static InputConfiguration SetAltPositiveButton(
            this InputConfiguration inputSettings,
            MouseButton? mouseButtonNumber)
        {
            return inputSettings
                .SetAltPositiveButton(UnityButtonNameFormat.MouseButtonName(mouseButtonNumber));
        }

        public static InputConfiguration SetNegativeButton(
            this InputConfiguration inputSettings,
            string negativeButton)
        {
            return inputSettings
                .Configure(negativeButton: negativeButton);
        }
        public static InputConfiguration SetNegativeButton(
            this InputConfiguration inputSettings,
            JoystickNumber joystickNumber,
            JoystickButton? joystickButtonNumber)
        {
            return inputSettings
                .SetNegativeButton(UnityButtonNameFormat.JoystickButtonName(joystickNumber, joystickButtonNumber));
        }
        public static InputConfiguration SetNegativeButton(
            this InputConfiguration inputSettings,
            MouseButton? mouseButtonNumber)
        {
            return inputSettings
                .SetNegativeButton(UnityButtonNameFormat.MouseButtonName(mouseButtonNumber));
        }

        public static InputConfiguration SetAltNegativeButton(
            this InputConfiguration inputSettings,
            string negativeButton)
        {
            return inputSettings
                .Configure(altNegativeButton: negativeButton);
        }
        public static InputConfiguration SetAltNegativeButton(
            this InputConfiguration inputSettings,
            JoystickNumber joystickNumber,
            JoystickButton? joystickButtonNumber)
        {
            return inputSettings
                .SetAltNegativeButton(UnityButtonNameFormat.JoystickButtonName(joystickNumber, joystickButtonNumber));
        }
        public static InputConfiguration SetAltNegativeButton(
            this InputConfiguration inputSettings,
            MouseButton? mouseButtonNumber)
        {
            return inputSettings
                .SetAltNegativeButton(UnityButtonNameFormat.MouseButtonName(mouseButtonNumber));
        }
    }
}
