namespace OpenInputManager
{
    public interface ISerializer<TObject, TSerialized>
    {
        void Serialize(TObject value, TSerialized serialized);
        void Deserialize(TObject value, TSerialized serialized);
    }
}
