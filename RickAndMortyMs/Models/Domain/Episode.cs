namespace RickAndMortyMs.Models.Domain
{
    public class Episode
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? AirDate { get; set; }
        public string? Code { get; set; }
        public IEnumerable<string>? Characters { get; set; }
        public Uri? Url { get; set; }
        public string? Created { get; set; }

    }
}
