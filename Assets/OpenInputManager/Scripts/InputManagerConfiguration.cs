using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace OpenInputManager
{
    [CreateAssetMenu(menuName = "Project Settings/Input Manager Configuration")]
    public class InputManagerConfiguration : ScriptableObject
    {
        public string AssetPath = InputManager.DefaultAssetPath;

        public List<InputInfo> Axes = new List<InputInfo>();

        public void LoadFromProjectSettings()
        {
            Axes = InputManager
                .ReadSettings(AssetPath)
                .ToList();

            EditorUtility.SetDirty(this);

            Debug.Log("Configuration loaded from project settings.");
        }
        public void SaveToProjectSettings()
        {
            InputManager.WriteSettings(Axes.ToArray(), AssetPath);

            Debug.Log("Configuration saved to project settings.");
        }
    }
}
