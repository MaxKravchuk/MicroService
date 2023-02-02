namespace RickAndMortyMs.Mapper.Interface
{
    public interface ITrippleMapper<TSource1,TSource2,TDestination>
    {
        TDestination Map(TSource1 source1, TSource2 source2);
    }
}
