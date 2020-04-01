using UnityEditor;

namespace OpenInputManager.Internals
{
    public static class InputConfigurationMapping
    {
        public static readonly StringProperty m_Name = new StringProperty("m_Name");
        public static readonly StringProperty descriptiveName = new StringProperty("descriptiveName");
        public static readonly StringProperty descriptiveNegativeName = new StringProperty("descriptiveNegativeName");
        public static readonly StringProperty negativeButton = new StringProperty("negativeButton");
        public static readonly StringProperty positiveButton = new StringProperty("positiveButton");
        public static readonly StringProperty altNegativeButton = new StringProperty("altNegativeButton");
        public static readonly StringProperty altPositiveButton = new StringProperty("altPositiveButton");
        public static readonly FloatProperty gravity = new FloatProperty("gravity");
        public static readonly FloatProperty dead = new FloatProperty("dead");
        public static readonly FloatProperty sensitivity = new FloatProperty("sensitivity");
        public static readonly BooleanProperty snap = new BooleanProperty("snap");
        public static readonly BooleanProperty invert = new BooleanProperty("invert");
        public static readonly Int32Property type = new Int32Property("type");
        public static readonly Int32Property axis = new Int32Property("axis");
        public static readonly Int32Property joyNum = new Int32Property("joyNum");

        public class ModelToUnityMapper : IMapper<InputConfiguration, SerializedProperty>
        {
            public void Map(InputConfiguration inputConfiguration, SerializedProperty serializedProperty)
            {
                serializedProperty.Set(m_Name, inputConfiguration.Name);
                serializedProperty.Set(descriptiveName, inputConfiguration.DescriptiveName);
                serializedProperty.Set(descriptiveNegativeName, inputConfiguration.DescriptiveNegativeName);
                serializedProperty.Set(negativeButton, inputConfiguration.NegativeButton);
                serializedProperty.Set(positiveButton, inputConfiguration.PositiveButton);
                serializedProperty.Set(altNegativeButton, inputConfiguration.AltNegativeButton);
                serializedProperty.Set(altPositiveButton, inputConfiguration.AltPositiveButton);
                serializedProperty.Set(gravity, inputConfiguration.Gravity);
                serializedProperty.Set(dead, inputConfiguration.Dead);
                serializedProperty.Set(sensitivity, inputConfiguration.Sensitivity);
                serializedProperty.Set(snap, inputConfiguration.Snap);
                serializedProperty.Set(invert, inputConfiguration.Invert);
                serializedProperty.Set(type, (int)inputConfiguration.AxisType);
                serializedProperty.Set(axis, (int)inputConfiguration.AxisNumber);
                serializedProperty.Set(joyNum, (int)inputConfiguration.JoystickNumber);
            }
        }
        public class UnityToModelMapper : IMapper<SerializedProperty, InputConfiguration>
        {
            public void Map(SerializedProperty serializedProperty, InputConfiguration inputConfiguration)
            {
                inputConfiguration.Name = serializedProperty.Get(m_Name);
                inputConfiguration.DescriptiveName = serializedProperty.Get(descriptiveName);
                inputConfiguration.DescriptiveNegativeName = serializedProperty.Get(descriptiveNegativeName);
                inputConfiguration.NegativeButton = serializedProperty.Get(negativeButton);
                inputConfiguration.PositiveButton = serializedProperty.Get(positiveButton);
                inputConfiguration.AltNegativeButton = serializedProperty.Get(altNegativeButton);
                inputConfiguration.AltPositiveButton = serializedProperty.Get(altPositiveButton);
                inputConfiguration.Gravity = serializedProperty.Get(gravity);
                inputConfiguration.Dead = serializedProperty.Get(dead);
                inputConfiguration.Sensitivity = serializedProperty.Get(sensitivity);
                inputConfiguration.Snap = serializedProperty.Get(snap);
                inputConfiguration.Invert = serializedProperty.Get(invert);
                inputConfiguration.AxisType = (AxisType)serializedProperty.Get(type);
                inputConfiguration.AxisNumber = (AxisNumber)serializedProperty.Get(axis);
                inputConfiguration.JoystickNumber = (JoystickNumber)serializedProperty.Get(joyNum);
            }
        }
    }
}
