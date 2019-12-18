using NUnit.Framework;
using OpenInputManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEditor;

namespace OpenInputManager
{
    public class ProjectSettingsTest
    {
        [Test]
        [TestCase(InputManager.SettingsAssetPath)]
        public void AssetPath_ContainsInputManager(string assetPath)
        {
            var asset = AssetDatabase.LoadAllAssetsAtPath(assetPath);

            Assert.AreEqual(1, asset.Length);
            Assert.AreEqual("InputManager", asset[0].GetType().Name);
        }

        [Test]
        [TestCase(InputManagerMapping.AxesPropertyPath)]
        public void SerializedInputManager_HasProperty(string propertyName)
        {
            // arrange
            var serializedSettings = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath(InputManager.SettingsAssetPath)[0]);

            // assert
            Assert.IsTrue(serializedSettings.FindProperty(propertyName) != null);
        }

        [Test]
        [TestCase(InputSettingsMapping.NameProperty)]
        [TestCase(InputSettingsMapping.DescriptiveNameProperty)]
        [TestCase(InputSettingsMapping.DescriptiveNegativeNameProperty)]
        [TestCase(InputSettingsMapping.NegativeButtonProperty)]
        [TestCase(InputSettingsMapping.PositiveButtonProperty)]
        [TestCase(InputSettingsMapping.AltNegativeButtonProperty)]
        [TestCase(InputSettingsMapping.AltPositiveButtonProperty)]
        [TestCase(InputSettingsMapping.GravityProperty)]
        [TestCase(InputSettingsMapping.DeadProperty)]
        [TestCase(InputSettingsMapping.SensitivityProperty)]
        [TestCase(InputSettingsMapping.SnapProperty)]
        [TestCase(InputSettingsMapping.InvertProperty)]
        [TestCase(InputSettingsMapping.AxisTypeProperty)]
        [TestCase(InputSettingsMapping.AxisNumberProperty)]
        [TestCase(InputSettingsMapping.JoystickNumberProperty)]
        public void SerializedInput_HasProperty(string propertyName)
        {
            // arrange
            var serializedSettings = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath(InputManager.SettingsAssetPath)[0]);

            var axesProperty = serializedSettings.FindProperty("m_Axes");
            axesProperty.arraySize = 1;

            var axis = axesProperty.GetArrayElementAtIndex(0);

            // assert
            Assert.IsTrue(axis.FindPropertyRelative(propertyName) != null);
        }
    }
}
