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
            public void Map(InputConfiguration inputSettings, SerializedProperty serializedProperty)
            {
                serializedProperty.Set(m_Name, inputSettings.Name);
                serializedProperty.Set(descriptiveName, inputSettings.DescriptiveName);
                serializedProperty.Set(descriptiveNegativeName, inputSettings.DescriptiveNegativeName);
                serializedProperty.Set(negativeButton, inputSettings.NegativeButton);
                serializedProperty.Set(positiveButton, inputSettings.PositiveButton);
                serializedProperty.Set(altNegativeButton, inputSettings.AltNegativeButton);
                serializedProperty.Set(altPositiveButton, inputSettings.AltPositiveButton);
                serializedProperty.Set(gravity, inputSettings.Gravity);
                serializedProperty.Set(dead, inputSettings.Dead);
                serializedProperty.Set(sensitivity, inputSettings.Sensitivity);
                serializedProperty.Set(snap, inputSettings.Snap);
                serializedProperty.Set(invert, inputSettings.Invert);
                serializedProperty.Set(type, (int)inputSettings.AxisType);
                serializedProperty.Set(axis, (int)inputSettings.AxisNumber);
                serializedProperty.Set(joyNum, (int)inputSettings.JoystickNumber);
            }
        }
        public class UnityToModelMapper : IMapper<SerializedProperty, InputConfiguration>
        {
            public void Map(SerializedProperty serializedProperty, InputConfiguration inputSettings)
            {
                inputSettings.Name = serializedProperty.Get(m_Name);
                inputSettings.DescriptiveName = serializedProperty.Get(descriptiveName);
                inputSettings.DescriptiveNegativeName = serializedProperty.Get(descriptiveNegativeName);
                inputSettings.NegativeButton = serializedProperty.Get(negativeButton);
                inputSettings.PositiveButton = serializedProperty.Get(positiveButton);
                inputSettings.AltNegativeButton = serializedProperty.Get(altNegativeButton);
                inputSettings.AltPositiveButton = serializedProperty.Get(altPositiveButton);
                inputSettings.Gravity = serializedProperty.Get(gravity);
                inputSettings.Dead = serializedProperty.Get(dead);
                inputSettings.Sensitivity = serializedProperty.Get(sensitivity);
                inputSettings.Snap = serializedProperty.Get(snap);
                inputSettings.Invert = serializedProperty.Get(invert);
                inputSettings.AxisType = (AxisType)serializedProperty.Get(type);
                inputSettings.AxisNumber = (AxisNumber)serializedProperty.Get(axis);
                inputSettings.JoystickNumber = (JoystickNumber)serializedProperty.Get(joyNum);
            }
        }
    }
}
