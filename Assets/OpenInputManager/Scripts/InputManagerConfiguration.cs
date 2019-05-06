using UnityEditor;
using UnityEngine;

namespace OpenInputManager
{
    [CreateAssetMenu(menuName = "Project Settings/Input Manager Configuration")]
    public class InputManagerConfiguration : ScriptableObject
    {
        public string AssetPath = InputManager.SettingsAssetPath;

        public InputManagerSettings InputManagerSettings;

        public void LoadFromProjectSettings()
        {
            InputManagerSettings = InputManager.ReadSettings();

            EditorUtility.SetDirty(this);

            Debug.Log("Configuration loaded from project settings.");
        }
        public void SaveToProjectSettings()
        {
            InputManager.WriteSettings(InputManagerSettings);

            Debug.Log("Configuration saved to project settings.");
        }
    }
}
