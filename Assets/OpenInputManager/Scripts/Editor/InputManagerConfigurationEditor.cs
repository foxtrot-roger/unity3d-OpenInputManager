using UnityEditor;
using UnityEngine;

namespace OpenInputManager
{
    [CustomEditor(typeof(InputManagerConfiguration))]
    public class InputManagerConfigurationEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            var data = (InputManagerConfiguration)target;

            DrawDefaultInspector();

            if (GUILayout.Button("Load from project settings"))
                data.LoadFromProjectSettings();

            if (GUILayout.Button("Save to project settings"))
                data.SaveToProjectSettings();
        }
    }
}
