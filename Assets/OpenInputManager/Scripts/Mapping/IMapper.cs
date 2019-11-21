namespace OpenInputManager
{
    public interface IMapper<TLeft, TRight>
    {
        void Map(TLeft source, TRight target);
    }
}
