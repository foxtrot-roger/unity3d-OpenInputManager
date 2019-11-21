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
            InputManagerSettings = InputManager.LoadFromProjectSettings();

            EditorUtility.SetDirty(this);

            Debug.Log("Configuration loaded from project settings.");
        }
        public void SaveToProjectSettings()
        {
            InputManager.SaveToProjectSettings(InputManagerSettings);

            Debug.Log("Configuration saved to project settings.");
        }
    }
}
