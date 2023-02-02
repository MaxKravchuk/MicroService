using RickAndMortyMs.Mapper.Interface;
using RickAndMortyMs.Models.Domain;
using RickAndMortyMs.Models.ViewModel;

namespace RickAndMortyMs.Mapper
{
    public class MapperToFullCharacterInfo : ITrippleMapper<Character, Location, CharacterFullInfoVM>
    {
        public CharacterFullInfoVM Map(Character source1, Location source2)
        {
            var characterFullInfoModel = new CharacterFullInfoVM()
            {
                name = source1.Name,
                gender = source1.Gender,
                origin = new CharacterOriginVM()
                {
                    name = source2.Name,
                    dimension = source2.Dimension,
                    type = source2.Type
                },
                species = source1.Species,
                status = source1.Status,
                type = source1.Type
            };
            return characterFullInfoModel;
        }
    }
}
