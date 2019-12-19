namespace OpenInputManager.Internals
{
    public interface IPropertyInfo<TOwner, TProperty>
    {
        string Name { get; }
        TProperty Of(TOwner owner);
    }
}