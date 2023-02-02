namespace RickAndMortyMs.Mapper.Interface
{
    public interface IMapper<TSource, TDestination>
    {
        TDestination Map(TSource source);
    }
}
