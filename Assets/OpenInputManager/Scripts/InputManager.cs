using System;
using UnityEditor;

namespace OpenInputManager
{
    public static class InputManager
    {
        public const string SettingsAssetPath = "ProjectSettings/InputManager.asset";

        public static event Action<string, InputManagerSettings> OnSettingsSaved;

        public static SerializedObject GetSeriallizedInputManager(string settingsAssetPath = SettingsAssetPath)
        {
            var inputManager = AssetDatabase.LoadAllAssetsAtPath(settingsAssetPath)[0];
            var serializedObject = new SerializedObject(inputManager);
            return serializedObject;
        }
        public static ISerializer<InputManagerSettings, SerializedObject> GetInputManagerSerializer()
        {
            return new InputManagerSettingsSerializer(new InputSettingsSerializer());
        }

        public static InputManagerSettings LoadFromProjectSettings(string settingsAssetPath = SettingsAssetPath)
        {
            var inputManagerSettings = new InputManagerSettings();

            Deserialize(
                GetInputManagerSerializer(),
                inputManagerSettings,
                GetSeriallizedInputManager(settingsAssetPath));

            return inputManagerSettings;
        }
        public static void SaveToProjectSettings(InputManagerSettings inputManagerSettings, string settingsAssetPath = SettingsAssetPath)
        {
            Serialize(GetInputManagerSerializer(), inputManagerSettings, GetSeriallizedInputManager(settingsAssetPath));

            if (OnSettingsSaved != null)
                OnSettingsSaved(settingsAssetPath, inputManagerSettings);
        }

        public static void Deserialize(ISerializer<InputManagerSettings, SerializedObject> serializer, InputManagerSettings inputManagerSettings, SerializedObject serializedObject)
        {
            using (serializedObject)
                serializer.Deserialize(inputManagerSettings, serializedObject);
        }
        public static void Serialize(ISerializer<InputManagerSettings, SerializedObject> serializer, InputManagerSettings inputManagerSettings, SerializedObject serializedObject)
        {
            using (serializedObject)
            {
                serializer.Serialize(inputManagerSettings, serializedObject);
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}
