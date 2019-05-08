using OpenInputManager;
using UnityEditor;
using UnityEngine;

public class InputSettingsDisplayComponent : MonoBehaviour
{
    float currentDeltaTime = 0;
    public float RefreshRate = 2;

    public InputManagerSettings InputManagerSettings;

    void Update()
    {
        currentDeltaTime += Time.deltaTime;
        if (RefreshRate <= currentDeltaTime)
        {
            InputManagerSettings = InputManager.LoadFromProjectSettings();

            EditorUtility.SetDirty(this);
            currentDeltaTime = 0;
        }
    }
}
