using NUnit.Framework;
using OpenInputManager.Internals;
using UnityEditor;

namespace OpenInputManager.Test
{
    public class ProjectSettingsTest
    {
        [Test]
        public void InputManager_HasCorrectType()
        {
            Assert.AreEqual("InputManager", ProjectSettings.InputManager.LoadAsset().GetType().Name);
        }

        [Test]
        public void InputManager_HasAxesProperty()
        {
            // arrange
            var serializedObject = new SerializedObject(ProjectSettings.InputManager.LoadAsset());

            // assert
            Assert.IsTrue(serializedObject.HasProperty(InputManagerMapping.m_Axes));
        }

        [Test]
        public void InputManager_Axes_HasProperty_m_Name()
        { InputManagerHasProperty(InputConfigurationMapping.m_Name); }

        [Test]
        public void InputManager_Axes_HasProperty_descriptiveName()
        { InputManagerHasProperty(InputConfigurationMapping.descriptiveName); }

        [Test]
        public void InputManager_Axes_HasProperty_descriptiveNegativeName()
        { InputManagerHasProperty(InputConfigurationMapping.descriptiveNegativeName); }

        [Test]
        public void InputManager_Axes_HasProperty_negativeButton()
        { InputManagerHasProperty(InputConfigurationMapping.negativeButton); }

        [Test]
        public void InputManager_Axes_HasProperty_positiveButton()
        { InputManagerHasProperty(InputConfigurationMapping.positiveButton); }

        [Test]
        public void InputManager_Axes_HasProperty_altNegativeButton()
        { InputManagerHasProperty(InputConfigurationMapping.altNegativeButton); }

        [Test]
        public void InputManager_Axes_HasProperty_altPositiveButton()
        { InputManagerHasProperty(InputConfigurationMapping.altPositiveButton); }

        [Test]
        public void InputManager_Axes_HasProperty_gravity()
        { InputManagerHasProperty(InputConfigurationMapping.gravity); }

        [Test]
        public void InputManager_Axes_HasProperty_dead()
        { InputManagerHasProperty(InputConfigurationMapping.dead); }

        [Test]
        public void InputManager_Axes_HasProperty_sensitivity()
        { InputManagerHasProperty(InputConfigurationMapping.sensitivity); }

        [Test]
        public void InputManager_Axes_HasProperty_snap()
        { InputManagerHasProperty(InputConfigurationMapping.snap); }

        [Test]
        public void InputManager_Axes_HasProperty_invert()
        { InputManagerHasProperty(InputConfigurationMapping.invert); }

        [Test]
        public void InputManager_Axes_HasProperty_type()
        { InputManagerHasProperty(InputConfigurationMapping.type); }

        [Test]
        public void InputManager_Axes_HasProperty_axis()
        { InputManagerHasProperty(InputConfigurationMapping.axis); }

        [Test]
        public void InputManager_Axes_HasProperty_joyNum()
        { InputManagerHasProperty(InputConfigurationMapping.joyNum); }


        void InputManagerHasProperty(IPropertyInfo<SerializedProperty, SerializedProperty> property)
        {
            // arrange
            var serializedObject = new SerializedObject(ProjectSettings.InputManager.LoadAsset());

            var axes = serializedObject.GetProperty(InputManagerMapping.m_Axes);
            axes.arraySize = 1;

            var axis = axes.GetArrayElementAtIndex(0);

            // assert
            Assert.IsTrue(axis.HasProperty(property));
        }
    }
}
