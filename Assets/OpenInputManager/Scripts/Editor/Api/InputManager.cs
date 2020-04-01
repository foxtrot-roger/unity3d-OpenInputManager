using OpenInputManager.Internals;
using System.Collections.Generic;
using UnityEditor;

namespace OpenInputManager
{
    public class InputManager
    {
        public List<InputConfiguration> Axes;

        public void Save()
        {
            using (var serializedObject = new SerializedObject(ProjectSettings.InputManager.LoadAsset()))
            {
                Mapper
                    .CreateModelToUnityMapper()
                    .Map(this, serializedObject);

                serializedObject.ApplyModifiedProperties();
            }
        }

        public static InputManager FromProjectSettings()
        {
            var inputManager = new InputManager();

            using (var serializedObject = new SerializedObject(ProjectSettings.InputManager.LoadAsset()))
                Mapper
                    .CreateUnityToModelMapper()
                    .Map(serializedObject, inputManager);

            return inputManager;
        }
    }
}
