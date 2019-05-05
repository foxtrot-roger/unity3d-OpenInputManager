using System;

namespace OpenInputManager
{
    [Serializable]
    public class InputInfo
    {
        public string Name;
        public string DescriptiveName;
        public string DescriptiveNegativeName;
        public string NegativeButton;
        public string PositiveButton;
        public string AltNegativeButton;
        public string AltPositiveButton;
        public float Gravity;
        public float Dead;
        public float Sensitivity;
        public bool Snap;
        public bool Invert;
        public AxisType AxisType;
        public AxisNumber AxisNumber;
        public JoystickNumber JoystickNumber;
    }
}
