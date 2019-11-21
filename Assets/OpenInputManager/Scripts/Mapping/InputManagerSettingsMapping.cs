using System.Collections.Generic;
using UnityEditor;

namespace OpenInputManager
{
    public static class InputManagerSettingsMapping
    {
        public const string AxesPropertyPath = "m_Axes";

        public class ModelToUnityMapper : IMapper<InputManagerSettings, SerializedObject>
        {
            readonly IMapper<InputSettings, SerializedProperty> _propertyMapper;

            public ModelToUnityMapper(IMapper<InputSettings, SerializedProperty> inputSettingsSerializer)
            {
                _propertyMapper = inputSettingsSerializer;
            }

            public void Map(InputManagerSettings inputManagerSettings, SerializedObject serializedObject)
            {
                int settingsCount = 0;
                if (inputManagerSettings.Axes != null)
                    settingsCount = inputManagerSettings.Axes.Count;

                var axesProperty = serializedObject.FindProperty(AxesPropertyPath);
                axesProperty.arraySize = settingsCount;

                for (int i = 0; i < settingsCount; i++)
                    _propertyMapper.Map(inputManagerSettings.Axes[i], axesProperty.GetArrayElementAtIndex(i));
            }
        }
        public class UnityToModelMapper : IMapper<SerializedObject, InputManagerSettings>
        {
            readonly IMapper<SerializedProperty, InputSettings> _propertyMapper;

            public UnityToModelMapper(IMapper<SerializedProperty, InputSettings> propertyMapper)
            {
                _propertyMapper = propertyMapper;
            }

            public void Map(SerializedObject serializedObject, InputManagerSettings inputManagerSettings)
            {
                var axesProperty = serializedObject.FindProperty(AxesPropertyPath);
                var settingsCount = axesProperty.arraySize;

                inputManagerSettings.Axes = inputManagerSettings.Axes ?? new List<InputSettings>();
                inputManagerSettings.Axes.Clear();

                for (int i = 0; i < settingsCount; i++)
                {
                    inputManagerSettings.Axes.Add(new InputSettings());
                    _propertyMapper.Map(axesProperty.GetArrayElementAtIndex(i), inputManagerSettings.Axes[i]);
                }
            }
        }
    }
}
