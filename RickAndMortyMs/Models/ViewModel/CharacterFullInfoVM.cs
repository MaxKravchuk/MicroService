namespace RickAndMortyMs.Models.ViewModel
{
    public class CharacterFullInfoVM
    {
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public CharacterOriginVM origin { get; set; }
    }
}
