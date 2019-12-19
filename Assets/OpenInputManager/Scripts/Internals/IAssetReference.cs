namespace OpenInputManager.Internals
{
    public interface IAssetReference<T>
    {
        T LoadAsset();
    }
}