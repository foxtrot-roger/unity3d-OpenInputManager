namespace OpenInputManager.Internals
{
    public interface IMapper<TLeft, TRight>
    {
        void Map(TLeft source, TRight target);
    }
}
