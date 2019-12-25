using System;
using UnityEngine;

namespace OpenInputManager
{
    public static class UnityButtonNameFormat
    {
        public const string UnityJoystickName = "joystick";
        public const string UnityJoystickButtonName = "button";
        public const string UnityMouseButtonName = "mouse";

        public static string JoystickButtonName(
            JoystickNumber joystickNumber,
            JoystickButton? joystickButton,
            string joystickName = UnityJoystickName,
            string joystickButtonName = UnityJoystickButtonName)
        {
            return joystickButton == null
                ? null
                : JoystickButtonName(joystickNumber, (JoystickButton)joystickButton, joystickName, joystickButtonName);
        }
        public static string JoystickButtonName(
            JoystickNumber joystickNumber,
            JoystickButton joystickButton,
            string joystickName = UnityJoystickName,
            string joystickButtonName = UnityJoystickButtonName)
        {
            return JoystickName(joystickNumber, joystickName) + " " + JoystickButtonName(joystickButton, joystickButtonName);
        }
        public static string JoystickButtonName(
            JoystickButton joystickButton,
            string joystickButtonName = UnityJoystickButtonName)
        {
            return joystickButtonName + " " + (int)joystickButton;
        }
        public static string JoystickName(
            JoystickNumber joystickNumber,
            string joystickName = UnityJoystickName)
        {
            if (joystickNumber == JoystickNumber.AllJoysticks)
                return joystickName;

            else
                return joystickName + " " + (int)joystickNumber;
        }

        public static string MouseButtonName(
            MouseButton? mouseButton,
            string mouseButtonName = UnityMouseButtonName)
        {
            return mouseButton == null
                ? null
                : MouseButtonName((MouseButton)mouseButton, mouseButtonName);
        }
        public static string MouseButtonName(
            MouseButton mouseButton,
            string mouseButtonName = UnityMouseButtonName)
        {
            return mouseButtonName + " " + (int)mouseButton;
        }


        public const int UnityJoystickButtonCount = KeyCode.Joystick2Button0 - KeyCode.Joystick1Button0;
        public static KeyCode UnityKeyCode(this MouseButton mouseButton)
        {
            if (mouseButton > MouseButton.Mouse6)
                throw new NotSupportedException("KeyCode for mouse button is only supported up to mouse button 6.");

            else
                return KeyCode.Mouse0 + (int)mouseButton;
        }
        public static KeyCode UnityKeyCode(JoystickNumber joystickNumber, JoystickButton joystickButton)
        {
            if (joystickNumber > JoystickNumber.Joystick8)
                throw new NotSupportedException("KeyCode for joystick button is only supported up to joystick 8.");

            else if ((int)joystickButton > UnityJoystickButtonCount)
                throw new NotSupportedException("KeyCode for joystick button is only supported up to button " + UnityJoystickButtonCount + ".");

            else
                return KeyCode.JoystickButton0 + ((int)joystickButton * UnityJoystickButtonCount) + (int)joystickButton;
        }
    }
}
