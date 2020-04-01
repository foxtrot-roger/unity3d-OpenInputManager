namespace OpenInputManager.Internals
{
    public static class PropertyInfoExtension
    {
        public static bool HasProperty<TOwner, TProperty>(this TOwner owner, IPropertyInfo<TOwner, TProperty> property)
        { return property.Of(owner) != null; }

        public static TProperty GetProperty<TOwner, TProperty>(this TOwner owner, IPropertyInfo<TOwner, TProperty> property)
        { return property.Of(owner); }
    }
}