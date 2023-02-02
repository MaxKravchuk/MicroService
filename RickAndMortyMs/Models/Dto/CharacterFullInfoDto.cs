namespace RickAndMortyMs.Models.Dto
{
    public class CharacterFullInfoDto
    {
        public string name { get; set; }
        public string status { get; set; }
        public string species { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public CharacterOriginDto origin { get; set; }
    }
}
