using System;
using UnityEditor;
using UnityEngine;

namespace OpenInputManager
{
    public static class InputManager
    {
        public const string DefaultAssetPath = "ProjectSettings/InputManager.asset";

        public const string UnityJoystickName = "joystick";

        public const string UnityJoystickButtonName = "button";
        public const int UnityJoystickButtonCount = 20;

        public const string UnityMouseButtonName = "mouse";

        public static InputInfo[] ReadSettings(string assetPath = DefaultAssetPath)
        {
            using (var inputManager = GetSeriallizedInputManager(assetPath))
            {
                var axesProperty = GetAxesProperty(inputManager);
                var arraySize = axesProperty.arraySize;

                var axes = new InputInfo[arraySize];
                for (int i = 0; i < arraySize; i++)
                    axes[i] = ReadSettings(axesProperty.GetArrayElementAtIndex(i));

                return axes;
            }
        }
        static InputInfo ReadSettings(SerializedProperty serializedProperty)
        {
            var axis = new InputInfo();

            axis.Name = serializedProperty.FindPropertyRelative("m_Name").stringValue;
            axis.DescriptiveName = serializedProperty.FindPropertyRelative("descriptiveName").stringValue;
            axis.DescriptiveNegativeName = serializedProperty.FindPropertyRelative("descriptiveNegativeName").stringValue;
            axis.NegativeButton = serializedProperty.FindPropertyRelative("negativeButton").stringValue;
            axis.PositiveButton = serializedProperty.FindPropertyRelative("positiveButton").stringValue;
            axis.AltNegativeButton = serializedProperty.FindPropertyRelative("altNegativeButton").stringValue;
            axis.AltPositiveButton = serializedProperty.FindPropertyRelative("altPositiveButton").stringValue;
            axis.Gravity = serializedProperty.FindPropertyRelative("gravity").floatValue;
            axis.Dead = serializedProperty.FindPropertyRelative("dead").floatValue;
            axis.Sensitivity = serializedProperty.FindPropertyRelative("sensitivity").floatValue;
            axis.Snap = serializedProperty.FindPropertyRelative("snap").boolValue;
            axis.Invert = serializedProperty.FindPropertyRelative("invert").boolValue;
            axis.AxisType = (AxisType)serializedProperty.FindPropertyRelative("type").intValue;
            axis.AxisNumber = (AxisNumber)serializedProperty.FindPropertyRelative("axis").intValue;
            axis.JoystickNumber = (JoystickNumber)serializedProperty.FindPropertyRelative("joyNum").intValue;

            return axis;
        }

        public static void WriteSettings(InputInfo[] axes, string assetPath = DefaultAssetPath)
        {
            using (var inputManager = GetSeriallizedInputManager(assetPath))
            {
                var axesProperty = GetAxesProperty(inputManager);

                var arraySize = axes.Length;

                axesProperty.arraySize = arraySize;
                for (int i = 0; i < arraySize; i++)
                    WriteSettings(axes[i], axesProperty.GetArrayElementAtIndex(i));

                inputManager.ApplyModifiedProperties();
            }
        }
        static void WriteSettings(InputInfo axis, SerializedProperty serializedProperty)
        {
            serializedProperty.FindPropertyRelative("m_Name").stringValue = axis.Name;
            serializedProperty.FindPropertyRelative("descriptiveName").stringValue = axis.DescriptiveName;
            serializedProperty.FindPropertyRelative("descriptiveNegativeName").stringValue = axis.DescriptiveNegativeName;
            serializedProperty.FindPropertyRelative("negativeButton").stringValue = axis.NegativeButton;
            serializedProperty.FindPropertyRelative("positiveButton").stringValue = axis.PositiveButton;
            serializedProperty.FindPropertyRelative("altNegativeButton").stringValue = axis.AltNegativeButton;
            serializedProperty.FindPropertyRelative("altPositiveButton").stringValue = axis.AltPositiveButton;
            serializedProperty.FindPropertyRelative("gravity").floatValue = axis.Gravity;
            serializedProperty.FindPropertyRelative("dead").floatValue = axis.Dead;
            serializedProperty.FindPropertyRelative("sensitivity").floatValue = axis.Sensitivity;
            serializedProperty.FindPropertyRelative("snap").boolValue = axis.Snap;
            serializedProperty.FindPropertyRelative("invert").boolValue = axis.Invert;
            serializedProperty.FindPropertyRelative("type").intValue = (int)axis.AxisType;
            serializedProperty.FindPropertyRelative("axis").intValue = (int)axis.AxisNumber;
            serializedProperty.FindPropertyRelative("joyNum").intValue = (int)axis.JoystickNumber;
        }

        public static InputInfo WithAxisSettings(this InputInfo inputInfo, float? gravity = null, float? dead = null, float? sensitivity = null, bool? snap = null, bool? invert = null)
        {
            inputInfo.Gravity = gravity ?? inputInfo.Gravity;
            inputInfo.Dead = dead ?? inputInfo.Dead;
            inputInfo.Sensitivity = sensitivity ?? inputInfo.Sensitivity;
            inputInfo.Snap = snap ?? inputInfo.Snap;
            inputInfo.Invert = invert ?? inputInfo.Invert;

            return inputInfo;
        }

        public static InputInfo Button(string inputName, string unityButtonName)
        {
            return new InputInfo
            {
                Name = inputName,
                PositiveButton = unityButtonName,
                AxisType = AxisType.KeyOrMouseButton
            };
        }
        public static InputInfo ButtonAxis(string inputName, string positiveUnityButtonName, string negativeUnityButtonName)
        {
            return new InputInfo
            {
                Name = inputName,
                NegativeButton = negativeUnityButtonName,
                PositiveButton = positiveUnityButtonName,
                Sensitivity = 1,
                Dead = 0.19f,
                AxisType = AxisType.KeyOrMouseButton
            };
        }

        public static InputInfo JoystickButton(JoystickNumber joystickNumber, JoystickButtonNumber joystickButtonNumber)
        {
            return JoystickButton(UniqueName(joystickNumber, joystickButtonNumber), joystickNumber, joystickButtonNumber);
        }
        public static InputInfo JoystickButton(string inputName, JoystickNumber joystickNumber, JoystickButtonNumber joystickButtonNumber)
        {
            return Button(inputName, UnityInputName(joystickNumber, joystickButtonNumber));
        }
        public static InputInfo JoystickAxis(JoystickNumber joystickNumber, AxisNumber axisNumber)
        {
            return JoystickAxis(UniqueName(joystickNumber, axisNumber), joystickNumber, axisNumber);
        }
        public static InputInfo JoystickAxis(string inputName, JoystickNumber joystickNumber, AxisNumber axisNumber)
        {
            return new InputInfo
            {
                Name = inputName,
                Sensitivity = 1,
                Dead = 0.19f,
                AxisType = AxisType.JoystickAxis,
                JoystickNumber = joystickNumber,
                AxisNumber = axisNumber
            };
        }

        public static InputInfo MouseButton(MouseButtonNumber mouseButtonNumber)
        {
            return MouseButton(UniqueName(mouseButtonNumber), mouseButtonNumber);
        }
        public static InputInfo MouseButton(string inputName, MouseButtonNumber mouseButtonNumber)
        {
            return Button(inputName, UnityInputName(mouseButtonNumber));
        }
        public static InputInfo MouseAxis(AxisNumber axisNumber)
        {
            return MouseAxis(UniqueName(axisNumber), axisNumber);
        }
        public static InputInfo MouseAxis(string inputName, AxisNumber axisNumber)
        {
            return new InputInfo
            {
                Name = inputName,
                AxisType = AxisType.MouseMovement,
                AxisNumber = axisNumber
            };
        }

        public static KeyCode UnityKeyCode(this MouseButtonNumber mouseButtonNumber)
        {
            return KeyCode.Mouse0 + (int)mouseButtonNumber;
        }
        public static KeyCode UnityKeyCode(JoystickNumber joystickNumber, JoystickButtonNumber joystickButtonNumber)
        {
            if (joystickNumber > JoystickNumber.Joystick8)
                throw new NotSupportedException("KeyCode for joystick button is only supported up to joystick 8.");

            else if (joystickNumber == JoystickNumber.AllJoysticks)
                return KeyCode.JoystickButton0 + (int)joystickButtonNumber;

            else
                return KeyCode.Joystick1Button0 + ((int)joystickButtonNumber * UnityJoystickButtonCount) + (int)joystickButtonNumber;
        }

        public static string UnityInputName(JoystickNumber joystickNumber, JoystickButtonNumber joystickButtonNumber, string joystickName = UnityJoystickName, string joystickButtonName = UnityJoystickButtonName)
        {
            return joystickNumber.UnityInputName(joystickName) + " " + joystickButtonNumber.UnityInputName(joystickButtonName);
        }
        public static string UnityInputName(this JoystickNumber joystickNumber, string joystickName = UnityJoystickName)
        {
            if (joystickNumber == JoystickNumber.AllJoysticks)
                return joystickName;

            else
                return joystickName + " " + (int)joystickNumber;
        }
        public static string UnityInputName(this JoystickButtonNumber joystickButtonNumber, string joystickButtonName = UnityJoystickButtonName)
        {
            return joystickButtonName + " " + (int)joystickButtonNumber;
        }
        public static string UnityInputName(this MouseButtonNumber mouseButtonNumber, string mouseButtonName = UnityMouseButtonName)
        {
            return mouseButtonName + " " + (int)mouseButtonNumber;
        }

        public static string UniqueName(JoystickNumber joystickNumber, AxisNumber axisNumber)
        {
            return joystickNumber + "_" + axisNumber;
        }
        public static string UniqueName(JoystickNumber joystickNumber, JoystickButtonNumber joystickButtonNumber)
        {
            return joystickNumber + "_" + joystickButtonNumber;
        }
        public static string UniqueName(MouseButtonNumber mouseButtonNumber)
        {
            return "" + mouseButtonNumber;
        }
        public static string UniqueName(AxisNumber axisNumber)
        {
            return "Mouse_" + axisNumber;
        }
        public static string UniqueName(string unityButtonName)
        {
            return "Key_" + unityButtonName;
        }

        static SerializedObject GetSeriallizedInputManager(string assetPath)
        {
            var inputManager = AssetDatabase.LoadAllAssetsAtPath(assetPath)[0];
            var serializedObject = new SerializedObject(inputManager);
            return serializedObject;
        }
        static SerializedProperty GetAxesProperty(SerializedObject inputManager)
        {
            return inputManager.FindProperty("m_Axes");
        }
    }
}
