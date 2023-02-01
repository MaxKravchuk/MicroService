namespace RickAndMortyMs.Models.Dto.Pageing
{
    public class PageDto<T>
    {
        public PageInfoDto Info { get; set; }
        public IEnumerable<T> Results { get; set; }
    }
}
