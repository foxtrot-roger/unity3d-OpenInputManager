using UnityEditor;

namespace OpenInputManager.Internals
{
    public class SerializedObjectPropertyInfo : IPropertyInfo<SerializedObject, SerializedProperty>
    {
        public SerializedObjectPropertyInfo(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public SerializedProperty Of(SerializedObject owner)
        { return owner.FindProperty(Name); }
    }
}