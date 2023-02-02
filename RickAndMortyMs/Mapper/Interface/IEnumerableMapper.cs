namespace RickAndMortyMs.Mapper.Interface
{
    public interface IEnumerableMapper<TSource, TModelModel> : IMapper<TSource, TModelModel>
    {
        public IEnumerable<TModelModel> Map(IEnumerable<TSource> source)
        {
            return source.Select<TSource, TModelModel>(item => Map(item));
        }
    }
}
