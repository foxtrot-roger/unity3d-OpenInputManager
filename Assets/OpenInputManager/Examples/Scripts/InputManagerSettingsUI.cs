using OpenInputManager;
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

    public void SetModel(InputManager inputManagerSettings)
    {
        if (InputManager != null)
            DestroyUI();

        InputManager = inputManagerSettings;

        if (InputManager != null)
            CreateUI();
    }

    void UpdateSettings(string assetPath, InputManager newSettings)
    {
        SetModel(newSettings);
    }

    void CreateUI()
    {
        foreach (var inputSettings in InputManager.Axes)
        {
            var instance = Instantiate(InputSettingsUiPrefab, transform);
            var ui = instance.GetComponent<InputSettingsUI>();
            ui.SetModel(inputSettings);
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
