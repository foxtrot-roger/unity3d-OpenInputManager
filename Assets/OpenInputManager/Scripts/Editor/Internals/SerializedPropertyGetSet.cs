using UnityEditor;

namespace OpenInputManager.Internals
{
    public abstract class SerializedPropertyGetSet<T> : SerializedPropertyPropertyInfo, IPropertyGetSet<T>
    {
        protected SerializedPropertyGetSet(string propertyName)
            : base(propertyName)
        { }

        public abstract T GetValue(SerializedProperty serializedProperty);
        public abstract void SetValue(SerializedProperty serializedProperty, T value);

        protected SerializedProperty GetProperty(SerializedProperty serializedProperty)
        { return Of(serializedProperty); }
    }
}