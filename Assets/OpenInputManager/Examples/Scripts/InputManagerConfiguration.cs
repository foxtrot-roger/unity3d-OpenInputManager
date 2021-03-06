﻿using OpenInputManager;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Project Settings/Input Manager Configuration")]
public class InputManagerConfiguration : ScriptableObject
{
    public List<InputConfiguration> Axes;

    public void LoadFromProjectSettings()
    {
        Axes = InputManager.FromProjectSettings().Axes;

        EditorUtility.SetDirty(this);

        Debug.Log("Configuration loaded from project settings.");
    }
    public void SaveToProjectSettings()
    {
        new InputManager { Axes = Axes }.Save();

        Debug.Log("Configuration saved to project settings.");
    }
}
