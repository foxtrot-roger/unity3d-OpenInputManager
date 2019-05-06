using UnityEditor;
using UnityEngine;

namespace OpenInputManager
{
    [CreateAssetMenu(menuName = "Project Settings/Input Manager Configuration")]
    public class InputManagerConfiguration : ScriptableObject
    {
        public string AssetPath = InputManagerSettings.SettingsAssetPath;

        public InputManagerSettings InputManagerSettings;

        public void LoadFromProjectSettings()
        {
            InputManagerSettings = InputManagerSettings.FromAsset();

            EditorUtility.SetDirty(this);

            Debug.Log("Configuration loaded from project settings.");
        }
        public void SaveToProjectSettings()
        {
            InputManagerSettings.ToAsset(InputManagerSettings);

            Debug.Log("Configuration saved to project settings.");
        }
    }
}
