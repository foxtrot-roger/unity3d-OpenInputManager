using UnityEditor;

namespace OpenInputManager
{
    public static class InputConfigurationMapping
    {
        public const string NameProperty = "m_Name";
        public const string DescriptiveNameProperty = "descriptiveName";
        public const string DescriptiveNegativeNameProperty = "descriptiveNegativeName";
        public const string NegativeButtonProperty = "negativeButton";
        public const string PositiveButtonProperty = "positiveButton";
        public const string AltNegativeButtonProperty = "altNegativeButton";
        public const string AltPositiveButtonProperty = "altPositiveButton";
        public const string GravityProperty = "gravity";
        public const string DeadProperty = "dead";
        public const string SensitivityProperty = "sensitivity";
        public const string SnapProperty = "snap";
        public const string InvertProperty = "invert";
        public const string AxisTypeProperty = "type";
        public const string AxisNumberProperty = "axis";
        public const string JoystickNumberProperty = "joyNum";

        public class ModelToUnityMapper : IMapper<InputConfiguration, SerializedProperty>
        {
            public void Map(InputConfiguration inputSettings, SerializedProperty serializedProperty)
            {
                serializedProperty.FindPropertyRelative(NameProperty).stringValue = inputSettings.Name;
                serializedProperty.FindPropertyRelative(DescriptiveNameProperty).stringValue = inputSettings.DescriptiveName;
                serializedProperty.FindPropertyRelative(DescriptiveNegativeNameProperty).stringValue = inputSettings.DescriptiveNegativeName;
                serializedProperty.FindPropertyRelative(NegativeButtonProperty).stringValue = inputSettings.NegativeButton;
                serializedProperty.FindPropertyRelative(PositiveButtonProperty).stringValue = inputSettings.PositiveButton;
                serializedProperty.FindPropertyRelative(AltNegativeButtonProperty).stringValue = inputSettings.AltNegativeButton;
                serializedProperty.FindPropertyRelative(AltPositiveButtonProperty).stringValue = inputSettings.AltPositiveButton;
                serializedProperty.FindPropertyRelative(GravityProperty).floatValue = inputSettings.Gravity;
                serializedProperty.FindPropertyRelative(DeadProperty).floatValue = inputSettings.Dead;
                serializedProperty.FindPropertyRelative(SensitivityProperty).floatValue = inputSettings.Sensitivity;
                serializedProperty.FindPropertyRelative(SnapProperty).boolValue = inputSettings.Snap;
                serializedProperty.FindPropertyRelative(InvertProperty).boolValue = inputSettings.Invert;
                serializedProperty.FindPropertyRelative(AxisTypeProperty).intValue = (int)inputSettings.AxisType;
                serializedProperty.FindPropertyRelative(AxisNumberProperty).intValue = (int)inputSettings.AxisNumber;
                serializedProperty.FindPropertyRelative(JoystickNumberProperty).intValue = (int)inputSettings.JoystickNumber;
            }
        }
        public class UnityToModelMapper : IMapper<SerializedProperty, InputConfiguration>
        {
            public void Map(SerializedProperty serializedProperty, InputConfiguration inputSettings)
            {
                inputSettings.Name = serializedProperty.FindPropertyRelative(NameProperty).stringValue;
                inputSettings.DescriptiveName = serializedProperty.FindPropertyRelative(DescriptiveNameProperty).stringValue;
                inputSettings.DescriptiveNegativeName = serializedProperty.FindPropertyRelative(DescriptiveNegativeNameProperty).stringValue;
                inputSettings.NegativeButton = serializedProperty.FindPropertyRelative(NegativeButtonProperty).stringValue;
                inputSettings.PositiveButton = serializedProperty.FindPropertyRelative(PositiveButtonProperty).stringValue;
                inputSettings.AltNegativeButton = serializedProperty.FindPropertyRelative(AltNegativeButtonProperty).stringValue;
                inputSettings.AltPositiveButton = serializedProperty.FindPropertyRelative(AltPositiveButtonProperty).stringValue;
                inputSettings.Gravity = serializedProperty.FindPropertyRelative(GravityProperty).floatValue;
                inputSettings.Dead = serializedProperty.FindPropertyRelative(DeadProperty).floatValue;
                inputSettings.Sensitivity = serializedProperty.FindPropertyRelative(SensitivityProperty).floatValue;
                inputSettings.Snap = serializedProperty.FindPropertyRelative(SnapProperty).boolValue;
                inputSettings.Invert = serializedProperty.FindPropertyRelative(InvertProperty).boolValue;
                inputSettings.AxisType = (AxisType)serializedProperty.FindPropertyRelative(AxisTypeProperty).intValue;
                inputSettings.AxisNumber = (AxisNumber)serializedProperty.FindPropertyRelative(AxisNumberProperty).intValue;
                inputSettings.JoystickNumber = (JoystickNumber)serializedProperty.FindPropertyRelative(JoystickNumberProperty).intValue;
            }
        }
    }
}
