using UnityEditor;

namespace OpenInputManager.Internals
{
    public class Int32Property : SerializedPropertyGetSet<int>
    {
        public Int32Property(string propertyName)
            : base(propertyName)
        { }

        public override int GetValue(SerializedProperty serializedProperty)
        { return GetProperty(serializedProperty).intValue; }

        public override void SetValue(SerializedProperty serializedProperty, int value)
        { GetProperty(serializedProperty).intValue = value; }
    }
}