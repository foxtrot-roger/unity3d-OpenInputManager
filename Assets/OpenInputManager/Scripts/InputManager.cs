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

        public static IMapper<SerializedObject, InputManagerSettings> SerializedObjectToInputManagerSettingsMapper()
        {
            return new InputManagerMapping.SerializedObjectToInputManagerSettings(
                new InputSettingsMapping.SerializedPropertyToInputSettings());
        }
        public static IMapper<InputManagerSettings, SerializedObject> InputManagerSettingsToSerializedObjectMapper()
        {
            return new InputManagerMapping.InputManagerSettingsToSerializedObject(
                new InputSettingsMapping.InputSettingsToSerializedProperty());
        }

        public static InputManagerSettings GetCurrentSettings(string settingsAssetPath = SettingsAssetPath)
        {
            var inputManagerSettings = new InputManagerSettings();
            var mapper = SerializedObjectToInputManagerSettingsMapper();

            using (var serializedObject = GetSeriallizedAsset(settingsAssetPath))
                mapper.Map(serializedObject, inputManagerSettings);


            return inputManagerSettings;
        }
        public static void SetCurrentSettings(InputManagerSettings inputManagerSettings, string settingsAssetPath = SettingsAssetPath)
        {
            var mapper = InputManagerSettingsToSerializedObjectMapper();
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
