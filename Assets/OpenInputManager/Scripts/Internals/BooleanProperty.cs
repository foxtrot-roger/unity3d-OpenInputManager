using UnityEditor;

namespace OpenInputManager.Internals
{
    public class BooleanProperty : SerializedPropertyGetSet<bool>
    {
        public BooleanProperty(string propertyName)
            : base(propertyName)
        { }

        public override bool GetValue(SerializedProperty serializedProperty)
        { return GetProperty(serializedProperty).boolValue; }

        public override void SetValue(SerializedProperty serializedProperty, bool value)
        { GetProperty(serializedProperty).boolValue = value; }
    }
}