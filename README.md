## Overview
__OpenInputManager__ allows you to read and write to Unity's input manager from the code of your application.

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
var inputManagerSettings = InputManager.ReadSettings();

// [change settings or do something with them]

InputManager.WriteSettings(inputManagerSettings);
```
By default the path to the input manager settings is "ProjectSettings/InputManager.asset" in Unity but if it was to change, it is possible to still us the methods by providing the input manager settings path.
```c#
var pathToSettingsAsset = "some/new/path/to/asset";
var inputManagerSettings = InputManager.ReadSettings(pathToSettingsAsset);

// [change settings or do something with them]

InputManager.WriteSettings(inputManagerSettings, pathToSettingsAsset);
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
  .ConfigureButtonAxis("w", "d" );
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
  .ConfigureButtonAxis(JoystickButtonNumber.Button0, JoystickButtonNumber.Button1 );
```

## How does it work?
### tldr;
It hacks into the Unity's private InputManager class.
### Really
It gets the InputManager from the AssetDatabase of the project, wraps it into a <c>SerializedObject</c> then map it to simple C# classes.

## Notes
### On performances
* Obviously we're accessing data through <c>SerializedObject</c> so expect it to be fairly slow (ie. don't go read ever frame).
* Less obvious, we're creating objects that are <c>class</c>, not <c>struct</c> so there will be some garbage created and the garbage collector will be used to clean it. 
### Other
* when you write settings, the new inputs can read within a second (from what I've tested)
