namespace RickAndMortyMs.Models.Domain
{
    public class Character
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? Species { get; set; }
        public string? Type { get; set; }
        public string? Gender { get; set; }
        public Origin Origin { get; set; }
        public Location? Location { get; set; }
        public Uri? Image { get; set; }
        public IEnumerable<Uri>? Episodes { get; set; }
        public Uri? Url { get; set;}
        public string? Created { get; set; }
    }
}
