using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace OpenInputManager
{
    public static class InputManagerMapping
    {
        public const string AxesPropertyPath = "m_Axes";

        public class ModelToUnityMapper : IMapper<InputManager, SerializedObject>
        {
            readonly IMapper<InputConfiguration, SerializedProperty> _propertyMapper;

            public ModelToUnityMapper(IMapper<InputConfiguration, SerializedProperty> inputSettingsSerializer)
            {
                _propertyMapper = inputSettingsSerializer;
            }

            public void Map(InputManager inputManager, SerializedObject serializedObject)
            {
                int settingsCount = 0;
                var axes = inputManager.Axes.ToArray();
                if (inputManager.Axes != null)
                    settingsCount = axes.Length;

                var axesProperty = serializedObject.FindProperty(AxesPropertyPath);
                axesProperty.arraySize = settingsCount;

                for (int i = 0; i < settingsCount; i++)
                    _propertyMapper.Map(axes[i], axesProperty.GetArrayElementAtIndex(i));
            }
        }
        public class UnityToModelMapper : IMapper<SerializedObject, InputManager>
        {
            readonly IMapper<SerializedProperty, InputConfiguration> _propertyMapper;

            public UnityToModelMapper(IMapper<SerializedProperty, InputConfiguration> propertyMapper)
            {
                _propertyMapper = propertyMapper;
            }

            public void Map(SerializedObject serializedObject, InputManager inputManager)
            {
                var axesProperty = serializedObject.FindProperty(AxesPropertyPath);
                var settingsCount = axesProperty.arraySize;

                var axes = new List<InputConfiguration>();
                for (int i = 0; i < settingsCount; i++)
                {
                    axes.Add(new InputConfiguration());
                    _propertyMapper.Map(axesProperty.GetArrayElementAtIndex(i), axes[i]);
                }

                inputManager.Axes = axes;
            }
        }
    }
}
