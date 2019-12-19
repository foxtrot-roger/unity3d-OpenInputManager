using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace OpenInputManager.Internals
{
    public static class InputManagerMapping
    {
        public static SerializedObjectPropertyInfo m_Axes = new SerializedObjectPropertyInfo("m_Axes");

        public class ModelToUnityMapper : IMapper<InputManager, SerializedObject>
        {
            readonly IMapper<InputConfiguration, SerializedProperty> _inputConfigurationMapper;

            public ModelToUnityMapper(IMapper<InputConfiguration, SerializedProperty> propertyMapper)
            {
                _inputConfigurationMapper = propertyMapper;
            }

            public void Map(InputManager inputManager, SerializedObject serializedObject)
            {
                int settingsCount = 0;
                var axes = inputManager.Axes.ToArray();
                if (inputManager.Axes != null)
                    settingsCount = axes.Length;

                var axesProperty = serializedObject.GetProperty(m_Axes);
                axesProperty.arraySize = settingsCount;

                for (int i = 0; i < settingsCount; i++)
                    _inputConfigurationMapper.Map(axes[i], axesProperty.GetArrayElementAtIndex(i));
            }
        }
        public class UnityToModelMapper : IMapper<SerializedObject, InputManager>
        {
            readonly IMapper<SerializedProperty, InputConfiguration> _inputConfigurationMapper;

            public UnityToModelMapper(IMapper<SerializedProperty, InputConfiguration> propertyMapper)
            {
                _inputConfigurationMapper = propertyMapper;
            }

            public void Map(SerializedObject serializedObject, InputManager inputManager)
            {
                var axesProperty = serializedObject.GetProperty(m_Axes);
                var settingsCount = axesProperty.arraySize;

                var axes = new List<InputConfiguration>();
                for (int i = 0; i < settingsCount; i++)
                {
                    axes.Add(new InputConfiguration());
                    _inputConfigurationMapper.Map(axesProperty.GetArrayElementAtIndex(i), axes[i]);
                }

                inputManager.Axes = axes;
            }
        }
    }
}
