using OpenInputManager;
using System;
using UnityEngine;

public class InputManagerSettingsUI : MonoBehaviour
{
    InputManager InputManager;
    public GameObject InputSettingsUiPrefab;

    void OnEnable()
    {
        InputManager = InputManager.FromProjectSettings();
    }

    void Start()
    {
        SetModel(InputManager.FromProjectSettings());
    }

    public void SetModel(InputManager inputManager)
    {
        if (InputManager != null)
            DestroyUI();

        InputManager = inputManager;

        if (InputManager != null)
            CreateUI();
    }

    [Obsolete]
    void UpdateSettings(string assetPath, InputManager newSettings)
    {
        SetModel(newSettings);
    }

    void CreateUI()
    {
        foreach (var inputConfiguration in InputManager.Axes)
        {
            var instance = Instantiate(InputSettingsUiPrefab, transform);
            var ui = instance.GetComponent<InputSettingsUI>();
            ui.SetModel(inputConfiguration);
        }
    }

    void DestroyUI()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            Destroy(child.gameObject);
        }
    }
}
