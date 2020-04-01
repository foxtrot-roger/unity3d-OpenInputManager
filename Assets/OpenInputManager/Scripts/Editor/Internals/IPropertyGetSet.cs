using UnityEditor;

namespace OpenInputManager.Internals
{
    public interface IPropertyGetSet<T> : IPropertyInfo<SerializedProperty, SerializedProperty>
    {
        T GetValue(SerializedProperty serializedProperty);
        void SetValue(SerializedProperty serializedProperty, T value);
    }
}