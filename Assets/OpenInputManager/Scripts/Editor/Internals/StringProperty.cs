using UnityEditor;

namespace OpenInputManager.Internals
{
    public class StringProperty : SerializedPropertyGetSet<string>
    {
        public StringProperty(string propertyName)
            : base(propertyName)
        { }

        public override string GetValue(SerializedProperty serializedProperty)
        { return GetProperty(serializedProperty).stringValue; }

        public override void SetValue(SerializedProperty serializedProperty, string value)
        { GetProperty(serializedProperty).stringValue = value; }
    }
}