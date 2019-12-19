using UnityEditor;

namespace OpenInputManager.Internals
{
    public class SerializedPropertyPropertyInfo : IPropertyInfo<SerializedProperty, SerializedProperty>
    {
        public SerializedPropertyPropertyInfo(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public SerializedProperty Of(SerializedProperty owner)
        { return owner.FindPropertyRelative(Name); }
    }
}