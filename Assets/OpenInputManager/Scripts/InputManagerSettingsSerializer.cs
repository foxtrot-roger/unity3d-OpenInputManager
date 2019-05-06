using System.Collections.Generic;
using UnityEditor;

namespace OpenInputManager
{
    public struct InputManagerSettingsSerializer : ISerializer<InputManagerSettings, SerializedObject>
    {
        public const string AxesPropertyPath = "m_Axes";

        readonly ISerializer<InputSettings, SerializedProperty> _inputSettingsSerializer;

        public InputManagerSettingsSerializer(ISerializer<InputSettings, SerializedProperty> inputSettingsSerializer)
        {
            _inputSettingsSerializer = inputSettingsSerializer;
        }

        public void Serialize(InputManagerSettings inputManagerSettings, SerializedObject serializedObject)
        {
            var settingsCount = inputManagerSettings.Axes?.Count ?? 0;

            var axesProperty = serializedObject.FindProperty(AxesPropertyPath);
            axesProperty.arraySize = settingsCount;

            for (int i = 0; i < settingsCount; i++)
                _inputSettingsSerializer.Serialize(inputManagerSettings.Axes[i], axesProperty.GetArrayElementAtIndex(i));
        }
        public void Deserialize(InputManagerSettings inputManagerSettings, SerializedObject serializedObject)
        {
            var axesProperty = serializedObject.FindProperty(AxesPropertyPath);
            var settingsCount = axesProperty.arraySize;

            inputManagerSettings.Axes = inputManagerSettings.Axes ?? new List<InputSettings>();
            inputManagerSettings.Axes.Clear();

            for (int i = 0; i < settingsCount; i++)
            {
                inputManagerSettings.Axes.Add(new InputSettings());
                _inputSettingsSerializer.Deserialize(inputManagerSettings.Axes[i], axesProperty.GetArrayElementAtIndex(i));
            }
        }
    }
}
