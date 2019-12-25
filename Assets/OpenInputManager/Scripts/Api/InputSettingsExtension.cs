namespace OpenInputManager
{
    public static class InputSettingsExtension
    {
        public static InputConfiguration Configure(this InputConfiguration inputConfiguration,
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
            inputConfiguration.Name = name ?? inputConfiguration.Name;
            inputConfiguration.DescriptiveName = descriptiveName ?? inputConfiguration.DescriptiveName;
            inputConfiguration.DescriptiveNegativeName = descriptiveNegativeName ?? inputConfiguration.DescriptiveNegativeName;

            inputConfiguration.NegativeButton = negativeButton ?? inputConfiguration.NegativeButton;
            inputConfiguration.PositiveButton = positiveButton ?? inputConfiguration.PositiveButton;
            inputConfiguration.AltNegativeButton = altNegativeButton ?? inputConfiguration.AltNegativeButton;
            inputConfiguration.AltPositiveButton = altPositiveButton ?? inputConfiguration.AltPositiveButton;

            inputConfiguration.Gravity = gravity ?? inputConfiguration.Gravity;
            inputConfiguration.Dead = dead ?? inputConfiguration.Dead;
            inputConfiguration.Sensitivity = sensitivity ?? inputConfiguration.Sensitivity;
            inputConfiguration.Snap = snap ?? inputConfiguration.Snap;
            inputConfiguration.Invert = invert ?? inputConfiguration.Invert;

            inputConfiguration.AxisType = axisType ?? inputConfiguration.AxisType;
            inputConfiguration.AxisNumber = axisNumber ?? inputConfiguration.AxisNumber;
            inputConfiguration.JoystickNumber = joystickNumber ?? inputConfiguration.JoystickNumber;

            return inputConfiguration;
        }

        public static InputConfiguration ConfigureInfo(
            this InputConfiguration inputConfiguration,
            string name,
            string descriptiveName = null,
            string descriptiveNegativeName = null)
        {
            return inputConfiguration.Configure(
                name: name,
                descriptiveName: descriptiveName,
                descriptiveNegativeName: descriptiveNegativeName);
        }

        public static InputConfiguration ConfigureButton(
            this InputConfiguration inputConfiguration,
            string positiveButton,
            string altPositiveButton = null)
        {
            return inputConfiguration
                .SetTypeKeyOrMouseButton()
                .SetPositiveButton(positiveButton)
                .SetAltPositiveButton(altPositiveButton);
        }
        public static InputConfiguration ConfigureButton(
            this InputConfiguration inputConfiguration,
            JoystickNumber joystickNumber,
            JoystickButton positiveJoystickButton,
            JoystickButton? altPositiveJoystickButton = null)
        {
            return inputConfiguration
                .SetTypeKeyOrMouseButton()
                .SetPositiveButton(joystickNumber, positiveJoystickButton)
                .SetAltPositiveButton(joystickNumber, altPositiveJoystickButton);
        }
        public static InputConfiguration ConfigureButton(
            this InputConfiguration inputConfiguration,
            MouseButton positiveButton,
            MouseButton? altPositiveButton = null)
        {
            return inputConfiguration
                .SetTypeKeyOrMouseButton()
                .SetPositiveButton(positiveButton)
                .SetAltPositiveButton(altPositiveButton);
        }

        public static InputConfiguration ConfigureButtonAxis(
            this InputConfiguration inputConfiguration,
            string negativeButton,
            string positiveButton,
            string altPositiveButton = null,
            string altNegativeButton = null)
        {
            return inputConfiguration
                .SetTypeKeyOrMouseButton()
                .SetPositiveButton(positiveButton)
                .SetAltPositiveButton(altPositiveButton)
                .SetNegativeButton(negativeButton)
                .SetAltNegativeButton(altNegativeButton);
        }
        public static InputConfiguration ConfigureButtonAxis(
            this InputConfiguration inputConfiguration,
            JoystickNumber joystickNumber,
            JoystickButton negativeButton,
            JoystickButton positiveButton,
            JoystickButton? altNegativeButton = null,
            JoystickButton? altPositiveButton = null)
        {
            return inputConfiguration
                .SetTypeKeyOrMouseButton()
                .SetPositiveButton(joystickNumber, positiveButton)
                .SetAltPositiveButton(joystickNumber, altPositiveButton)
                .SetNegativeButton(joystickNumber, negativeButton)
                .SetAltNegativeButton(joystickNumber, altNegativeButton);
        }
        public static InputConfiguration ConfigureButtonAxis(
            this InputConfiguration inputConfiguration,
            MouseButton negativeButton,
            MouseButton positiveButton,
            MouseButton? altNegativeButton = null,
            MouseButton? altPositiveButton = null)
        {
            return inputConfiguration
                .SetTypeKeyOrMouseButton()
                .SetPositiveButton(positiveButton)
                .SetAltPositiveButton(altPositiveButton)
                .SetNegativeButton(negativeButton)
                .SetAltNegativeButton(altNegativeButton);
        }

        public static InputConfiguration ConfigureMouseMovement(
            this InputConfiguration inputConfiguration,
            AxisNumber axisNumber)
        {
            return inputConfiguration
                .SetTypeMouseMovement(axisNumber);
        }

        public static InputConfiguration ConfigureJoystickAxis(
            this InputConfiguration inputConfiguration,
            JoystickNumber joystickNumber,
            AxisNumber axisNumber)
        {
            return inputConfiguration
                .SetTypeJoystickAxis(joystickNumber, axisNumber);
        }

        public static InputConfiguration SetTypeKeyOrMouseButton(
            this InputConfiguration inputConfiguration)
        {
            return inputConfiguration.Configure(
                axisType: AxisType.KeyOrMouseButton,
                axisNumber: AxisNumber.AxisX,
                joystickNumber: JoystickNumber.AllJoysticks);
        }
        public static InputConfiguration SetTypeJoystickAxis(
            this InputConfiguration inputConfiguration,
            JoystickNumber joystickNumber,
            AxisNumber axisNumber)
        {
            return inputConfiguration.Configure(
                axisType: AxisType.JoystickAxis,
                joystickNumber: joystickNumber,
                axisNumber: axisNumber,
                sensitivity: 1);
        }
        public static InputConfiguration SetTypeMouseMovement(
            this InputConfiguration inputConfiguration,
            AxisNumber axisNumber)
        {
            return inputConfiguration.Configure(
                axisType: AxisType.MouseMovement,
                joystickNumber: JoystickNumber.AllJoysticks,
                axisNumber: axisNumber,
                sensitivity: 1);
        }

        public static InputConfiguration SetPositiveButton(
            this InputConfiguration inputConfiguration,
            string positiveButton)
        {
            return inputConfiguration
                .Configure(positiveButton: positiveButton);
        }
        public static InputConfiguration SetPositiveButton(
            this InputConfiguration inputConfiguration,
            JoystickNumber joystickNumber,
            JoystickButton? joystickButtonNumber)
        {
            return inputConfiguration
                .SetPositiveButton(UnityButtonNameFormat.JoystickButtonName(joystickNumber, joystickButtonNumber));
        }
        public static InputConfiguration SetPositiveButton(
            this InputConfiguration inputConfiguration,
            MouseButton? mouseButtonNumber)
        {
            return inputConfiguration
                .SetPositiveButton(UnityButtonNameFormat.MouseButtonName(mouseButtonNumber));
        }

        public static InputConfiguration SetAltPositiveButton(
            this InputConfiguration inputConfiguration,
            string positiveButton)
        {
            return inputConfiguration
                .Configure(altPositiveButton: positiveButton);
        }
        public static InputConfiguration SetAltPositiveButton(
            this InputConfiguration inputConfiguration,
            JoystickNumber joystickNumber,
            JoystickButton? joystickButtonNumber)
        {
            return inputConfiguration
                .SetAltPositiveButton(UnityButtonNameFormat.JoystickButtonName(joystickNumber, joystickButtonNumber));
        }
        public static InputConfiguration SetAltPositiveButton(
            this InputConfiguration inputConfiguration,
            MouseButton? mouseButtonNumber)
        {
            return inputConfiguration
                .SetAltPositiveButton(UnityButtonNameFormat.MouseButtonName(mouseButtonNumber));
        }

        public static InputConfiguration SetNegativeButton(
            this InputConfiguration inputConfiguration,
            string negativeButton)
        {
            return inputConfiguration
                .Configure(negativeButton: negativeButton);
        }
        public static InputConfiguration SetNegativeButton(
            this InputConfiguration inputConfiguration,
            JoystickNumber joystickNumber,
            JoystickButton? joystickButtonNumber)
        {
            return inputConfiguration
                .SetNegativeButton(UnityButtonNameFormat.JoystickButtonName(joystickNumber, joystickButtonNumber));
        }
        public static InputConfiguration SetNegativeButton(
            this InputConfiguration inputConfiguration,
            MouseButton? mouseButtonNumber)
        {
            return inputConfiguration
                .SetNegativeButton(UnityButtonNameFormat.MouseButtonName(mouseButtonNumber));
        }

        public static InputConfiguration SetAltNegativeButton(
            this InputConfiguration inputConfiguration,
            string negativeButton)
        {
            return inputConfiguration
                .Configure(altNegativeButton: negativeButton);
        }
        public static InputConfiguration SetAltNegativeButton(
            this InputConfiguration inputConfiguration,
            JoystickNumber joystickNumber,
            JoystickButton? joystickButtonNumber)
        {
            return inputConfiguration
                .SetAltNegativeButton(UnityButtonNameFormat.JoystickButtonName(joystickNumber, joystickButtonNumber));
        }
        public static InputConfiguration SetAltNegativeButton(
            this InputConfiguration inputConfiguration,
            MouseButton? mouseButtonNumber)
        {
            return inputConfiguration
                .SetAltNegativeButton(UnityButtonNameFormat.MouseButtonName(mouseButtonNumber));
        }
    }
}
