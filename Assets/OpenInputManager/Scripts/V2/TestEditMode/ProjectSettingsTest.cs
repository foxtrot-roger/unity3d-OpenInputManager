using NUnit.Framework;
using UnityEditor;

namespace OpenInputManager.Test
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
        [TestCase(InputConfigurationMapping.NameProperty)]
        [TestCase(InputConfigurationMapping.DescriptiveNameProperty)]
        [TestCase(InputConfigurationMapping.DescriptiveNegativeNameProperty)]
        [TestCase(InputConfigurationMapping.NegativeButtonProperty)]
        [TestCase(InputConfigurationMapping.PositiveButtonProperty)]
        [TestCase(InputConfigurationMapping.AltNegativeButtonProperty)]
        [TestCase(InputConfigurationMapping.AltPositiveButtonProperty)]
        [TestCase(InputConfigurationMapping.GravityProperty)]
        [TestCase(InputConfigurationMapping.DeadProperty)]
        [TestCase(InputConfigurationMapping.SensitivityProperty)]
        [TestCase(InputConfigurationMapping.SnapProperty)]
        [TestCase(InputConfigurationMapping.InvertProperty)]
        [TestCase(InputConfigurationMapping.AxisTypeProperty)]
        [TestCase(InputConfigurationMapping.AxisNumberProperty)]
        [TestCase(InputConfigurationMapping.JoystickNumberProperty)]
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
