## Overview
__OpenInputManager__ allows you to load and save settings into Unity's input manager from the code of your application.

## What does it do?
It allows you to configure _ProjectSettings/Input_ from your code.
After you have added or removed inputs, you can read them as you'd do normally through
* <code>Input.GetAxis("...")</code>
* <code>Input.GetButton("...")</code>
* <code>Input.GetButtonDown("...")</code>
* ...

## How to
### Read and write settings
```c#
var inputManager = InputManager.FromProjectSettings();

// [change settings or do something with them]

inputManager.Save();
```
By default the path to the input manager settings is "ProjectSettings/InputManager.asset" in Unity but if it was to change, it is possible to still use the methods by providing the InputManager a path to the settings asset.
```c#
var pathToSettingsAsset = "some/new/path/to/asset";
var inputManagerSettings = InputManager.FromAssetPath(pathToSettingsAsset);

// [change settings or do something with them]

inputManager.SaveToAssetPath(pathToSettingsAsset);
```
### Create buttons
#### Keyboard key
```c#
var keyboardKey = new InputSettings()
  .ConfigureInfo("name")
  .ConfigureButton("space");
```
#### Mouse button
```c#
var mouseButton = new InputSettings()
  .ConfigureInfo("name")
  .ConfigureButton(MouseButtonNumber.Mouse0);
```
#### Joystick button
```c#
var joystickButton = new InputSettings()
  .ConfigureInfo("name")
  .ConfigureButton(JoystickNumber.Joystick1, JoystickButtonNumber.Button0);
```
### Create axes
#### Keyboard key axis
```c#
var keyAxis = new InputSettings()
  .ConfigureInfo("name")
  .ConfigureButtonAxis("w", "d");
```
#### Joystick axis
```c#
var joystickAxis = new InputSettings()
  .ConfigureInfo("name")
  .ConfigureJoystickAxis(JoystickNumber.Joystick1, AxisNumber.AxisX);
```
#### Joystick button axis
```c#
var joystickAxis = new InputSettings()
  .ConfigureInfo("name")
  .ConfigureButtonAxis(JoystickButtonNumber.Button0, JoystickButtonNumber.Button1);
```

## How does it work?
### tldr;
It hacks into the Unity's private InputManager class.
### Really
It gets the InputManager from the AssetDatabase of the project, wraps it into a <c>SerializedObject</c> then map it to simple C# classes.

## Notes
### On performances
* Obviously we're accessing data through <c>SerializedObject</c> so expect it to be fairly slow (ie. don't go read every frame).
* Less obvious, we're creating objects that are <c>class</c>, not <c>struct</c> so there will be some garbage created and the garbage collector will be used to clean it. 
### UI and EventSystem
When using any kind of UI, you'll have an EventSystem in the scene, that EventSystem relies on specific axes to work properly, removing or renaming them will cause issues. If you wish to change them, make sure to update the _Standalone Input Module_ of the scene EventSystem.
The default axes used by the EventSystem are:
* Horizontal
* Vertical
* Submit
* Cancel
### Other
* After saving settings to the project, the new buttons and axes can be used within a second (from what I've tested)
* The _ProjectSettings/Input_ configuration is reset when exiting playmode