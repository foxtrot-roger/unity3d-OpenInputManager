using UnityEditor;

namespace OpenInputManager.Internals
{
    public static class SerializedPropertyExtension
    {
        public static T Get<T>(this SerializedProperty serializedProperty, IPropertyGetSet<T> getter)
        { return getter.GetValue(serializedProperty); }

        public static void Set<T>(this SerializedProperty serializedProperty, IPropertyGetSet<T> setter, T value)
        { setter.SetValue(serializedProperty, value); }
    }
}