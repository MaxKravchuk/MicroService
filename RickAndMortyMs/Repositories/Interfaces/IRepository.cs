namespace RickAndMortyMs.Repositories.Interfaces
{
    public interface IRepository
    {
        Task<T> Get<T>(string path);
        Task<IEnumerable<T>> GetPages<T>(string url);
    }
}
