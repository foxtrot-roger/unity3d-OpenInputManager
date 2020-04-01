using UnityEditor;

namespace OpenInputManager.Internals
{
    public class FloatProperty : SerializedPropertyGetSet<float>
    {
        public FloatProperty(string propertyName)
            : base(propertyName)
        { }

        public override float GetValue(SerializedProperty serializedProperty)
        { return GetProperty(serializedProperty).floatValue; }

        public override void SetValue(SerializedProperty serializedProperty, float value)
        { GetProperty(serializedProperty).floatValue = value; }
    }
}