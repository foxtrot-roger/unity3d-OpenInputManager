using System.Linq;
using UnityEditor;
using UnityEngine;

namespace OpenInputManager
{
    [CreateAssetMenu(menuName = "Project Settings/Input Manager Configuration")]
    public class InputManagerConfiguration : ScriptableObject
    {
        public string AssetPath = InputManager.SettingsAssetPath;

        public InputConfiguration[] Axes;

        public void LoadFromProjectSettings()
        {
            Axes = InputManager.FromProjectSettings().Axes.ToArray();

            EditorUtility.SetDirty(this);

            Debug.Log("Configuration loaded from project settings.");
        }
        public void SaveToProjectSettings()
        {
            new InputManager { Axes = Axes }.Save();

            Debug.Log("Configuration saved to project settings.");
        }
    }
}
