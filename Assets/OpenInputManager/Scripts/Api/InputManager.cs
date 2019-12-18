using System.Collections.Generic;

namespace OpenInputManager
{
    public class InputManager
    {
        public const string SettingsAssetPath = "ProjectSettings/InputManager.asset";

        public IEnumerable<InputConfiguration> Axes;

        public void Save()
        {
            SaveToAssetPath(SettingsAssetPath);
        }
        public void SaveToAssetPath(string assetPath)
        {
            var mapper = Mapper.CreateModelToUnityMapper();
            using (var serializedObject = AssetDatabaseHelper.LoadSerializedObjectAtPath(assetPath))
            {
                mapper.Map(this, serializedObject);
                serializedObject.ApplyModifiedProperties();
            }
        }

        public static InputManager FromProjectSettings()
        {
            return FromAssetPath(SettingsAssetPath);
        }
        public static InputManager FromAssetPath(string assetPath)
        {
            var inputManager = new InputManager();
            var mapper = Mapper.CreateUnityToModelMapper();

            using (var serializedObject = AssetDatabaseHelper.LoadSerializedObjectAtPath(assetPath))
                mapper.Map(serializedObject, inputManager);


            return inputManager;
        }
    }
}
