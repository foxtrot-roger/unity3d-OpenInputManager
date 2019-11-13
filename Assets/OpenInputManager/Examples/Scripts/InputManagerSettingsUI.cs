using OpenInputManager;
using UnityEngine;

public class InputManagerSettingsUI : MonoBehaviour
{
    InputManagerSettings InputManagerSettings;
    public GameObject InputSettingsUiPrefab;

    void OnEnable()
    {
        InputManagerSettings = InputManager.GetCurrentSettings();
        InputManager.OnSettingsSaved += UpdateSettings;
    }
    void OnDisable()
    {
        InputManager.OnSettingsSaved -= UpdateSettings;
    }
    void Start()
    {
        SetModel(InputManager.GetCurrentSettings());
    }

    public void SetModel(InputManagerSettings inputManagerSettings)
    {
        if (InputManagerSettings != null)
            DestroyUI();

        InputManagerSettings = inputManagerSettings;

        if (InputManagerSettings != null)
            CreateUI();
    }

    void UpdateSettings(string assetPath, InputManagerSettings newSettings)
    {
        SetModel(newSettings);
    }

    void CreateUI()
    {
        foreach (var inputSettings in InputManagerSettings.Axes)
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
