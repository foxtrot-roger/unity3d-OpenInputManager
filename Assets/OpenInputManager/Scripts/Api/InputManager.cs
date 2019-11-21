using System;
using UnityEditor;

namespace OpenInputManager
{
    public static class InputManager
    {
        public const string SettingsAssetPath = "ProjectSettings/InputManager.asset";

        public static event Action<string, InputManagerSettings> OnSettingsSaved;

        public static SerializedObject GetSeriallizedAsset(string settingsAssetPath = SettingsAssetPath)
        {
            var inputManager = AssetDatabase.LoadAllAssetsAtPath(settingsAssetPath)[0];
            var serializedObject = new SerializedObject(inputManager);
            return serializedObject;
        }

        public static InputManagerSettings LoadFromProjectSettings()
        {
            return LoadFromAsset(SettingsAssetPath);
        }
        public static InputManagerSettings LoadFromAsset(string settingsAssetPath)
        {
            var inputManagerSettings = new InputManagerSettings();
            var mapper = Mapper.CreateUnityToModelMapper();

            using (var serializedObject = GetSeriallizedAsset(settingsAssetPath))
                mapper.Map(serializedObject, inputManagerSettings);


            return inputManagerSettings;
        }

        public static void SaveToProjectSettings(InputManagerSettings inputManagerSettings)
        {
            SaveToAsset(inputManagerSettings, SettingsAssetPath);
        }
        public static void SaveToAsset(InputManagerSettings inputManagerSettings, string settingsAssetPath)
        {
            var mapper = Mapper.CreateModelToUnityMapper();
            using (var serializedObject = GetSeriallizedAsset(settingsAssetPath))
            {
                mapper.Map(inputManagerSettings, serializedObject);
                serializedObject.ApplyModifiedProperties();
            }

            if (OnSettingsSaved != null)
                OnSettingsSaved(settingsAssetPath, inputManagerSettings);
        }
    }
}
