using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace OpenInputManager.Test
{
    public class InputManagerTest
    {
        [Test]
        public void New_Succeeds()
        {
            new InputManager();
        }

        [Test]
        public void FromProjectSettings_Succeeds()
        {
            foreach (var axis in InputManager.FromProjectSettings().Axes)
            { }
        }
        [Test]
        public void Save_Succeeds()
        {
            // arrange
            var axes = new List<InputConfiguration> { };
            var inputManager = new InputManager { Axes = axes };

            // act
            inputManager.Save();
        }

        [Test]
        public void Add_EnablesAxis()
        {
            // arrange
            var axes = new List<InputConfiguration> { new InputConfiguration { Name = "TestAxis" } };
            var inputManager = new InputManager { Axes = axes };

            // act
            inputManager.Save();

            // assert
            Input.GetAxis(axes[0].Name);
        }
        [Test]
        public void Remove_DisablesAxis()
        {
            // arrange
            var oldSettings = InputManager.FromProjectSettings();

            var axes = new List<InputConfiguration> { };
            var inputManager = new InputManager { Axes = axes };

            // act
            inputManager.Save();

            // assert
            foreach (var axis in oldSettings.Axes)
                Assert.Throws<ArgumentException>(() => Input.GetAxis(axis.Name));
        }

        [Test]
        public void SaveAndLoadKeyboardButton_Succeeds()
        {
            // arrange
            var inputSettings = new InputConfiguration()
                .ConfigureInfo("TestAxis", "DescriptiveName", "DescriptiveNegativeName")
                .ConfigureButton("left", "a");

            // act & assert
            AssertSaveAndLoadAreEquivalent(inputSettings);
        }
        [Test]
        public void SaveAndLoadMouseButton_Succeeds()
        {
            // arrange
            var inputSettings = new InputConfiguration()
                .ConfigureInfo("TestAxis", "DescriptiveName", "DescriptiveNegativeName")
                .ConfigureButton(MouseButton.Mouse1, MouseButton.Mouse2);

            // act & assert
            AssertSaveAndLoadAreEquivalent(inputSettings);
        }
        [Test]
        public void SaveAndLoadJoystickButton_Succeeds()
        {
            // arrange
            var inputSettings = new InputConfiguration()
                .ConfigureInfo("TestAxis", "DescriptiveName", "DescriptiveNegativeName")
                .ConfigureButton(JoystickNumber.Joystick1, JoystickButton.Button1, JoystickButton.Button10);

            // act & assert
            AssertSaveAndLoadAreEquivalent(inputSettings);
        }

        [Test]
        public void SaveAndLoadKeyboardButtonAxis_Succeeds()
        {
            // arrange
            var inputSettings = new InputConfiguration()
                .ConfigureInfo("TestAxis", "DescriptiveName", "DescriptiveNegativeName")
                .ConfigureButtonAxis("right", "left", "a", "d");

            // act & assert
            AssertSaveAndLoadAreEquivalent(inputSettings);
        }
        [Test]
        public void SaveAndLoadMouseButtonAxis_Succeeds()
        {
            // arrange
            var inputSettings = new InputConfiguration()
                .ConfigureInfo("TestAxis", "DescriptiveName", "DescriptiveNegativeName")
                .ConfigureButtonAxis(MouseButton.Mouse2, MouseButton.Mouse1, MouseButton.Mouse4, MouseButton.Mouse3);

            // act & assert
            AssertSaveAndLoadAreEquivalent(inputSettings);
        }
        [Test]
        public void SaveAndLoadJoystickButtonAxis_Succeeds()
        {
            // arrange
            var inputSettings = new InputConfiguration()
                .ConfigureInfo("TestAxis", "DescriptiveName", "DescriptiveNegativeName")
                .ConfigureButtonAxis(JoystickNumber.Joystick1, JoystickButton.Button10, JoystickButton.Button1, JoystickButton.Button12, JoystickButton.Button11);

            // act & assert
            AssertSaveAndLoadAreEquivalent(inputSettings);
        }

        [Test]
        public void SaveAndLoadJoystickAxis_Succeeds()
        {
            // arrange
            var inputSettings = new InputConfiguration()
                .ConfigureInfo("TestAxis", "DescriptiveName", "DescriptiveNegativeName")
                .ConfigureJoystickAxis(JoystickNumber.Joystick1, AxisNumber.AxisY);

            // act & assert
            AssertSaveAndLoadAreEquivalent(inputSettings);
        }
        [Test]
        public void SaveAndLoadMouseMovement_Succeeds()
        {
            // arrange
            var inputSettings = new InputConfiguration()
                .ConfigureInfo("TestAxis", "DescriptiveName", "DescriptiveNegativeName")
                .ConfigureMouseMovement(AxisNumber.Axis3OrScrollwhell);

            // act & assert
            AssertSaveAndLoadAreEquivalent(inputSettings);
        }

        void AssertSaveAndLoadAreEquivalent(InputConfiguration inputSettings)
        {
            // arrange
            inputSettings.Configure(
                gravity: 5,
                sensitivity: 0.5f,
                snap: true,
                invert: true);

            var axes = new List<InputConfiguration> { inputSettings };
            var inputManager = new InputManager { Axes = axes };

            // act
            inputManager.Save();
            var newSettings = InputManager.FromProjectSettings();
            var newAxes = newSettings.Axes.ToArray();

            Assert.AreEqual(axes.Count(), newAxes.Length);
            for (int i = 0; i < axes.Count; i++)
                AssertAreEquivalent(axes[i], newAxes[i]);
        }

        void AssertAreEquivalent(InputConfiguration x, InputConfiguration y)
        {
            AssertStringAreEquivalent(x.AltNegativeButton, y.AltNegativeButton);
            AssertStringAreEquivalent(x.AltPositiveButton, y.AltPositiveButton);
            Assert.AreEqual(x.AxisNumber, y.AxisNumber);
            Assert.AreEqual(x.AxisType, y.AxisType);
            Assert.AreEqual(x.Dead, y.Dead);
            AssertStringAreEquivalent(x.DescriptiveName, y.DescriptiveName);
            AssertStringAreEquivalent(x.DescriptiveNegativeName, y.DescriptiveNegativeName);
            Assert.AreEqual(x.Gravity, y.Gravity);
            Assert.AreEqual(x.Invert, y.Invert);
            Assert.AreEqual(x.JoystickNumber, y.JoystickNumber);
            AssertStringAreEquivalent(x.Name, y.Name);
            AssertStringAreEquivalent(x.NegativeButton, y.NegativeButton);
            AssertStringAreEquivalent(x.PositiveButton, y.PositiveButton);
            Assert.AreEqual(x.Sensitivity, y.Sensitivity);
            Assert.AreEqual(x.Snap, y.Snap);
        }
        void AssertStringAreEquivalent(string x, string y)
        {
            Assert.AreEqual(x ?? string.Empty, y ?? string.Empty);
        }
    }
}
