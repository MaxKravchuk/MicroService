using RickAndMortyMs.Mapper.Interface;
using RickAndMortyMs.Models.Domain;
using RickAndMortyMs.Models.Dto;

namespace RickAndMortyMs.Mapper
{
    public class MapperToFullCharacterInfo : ITrippleMapper<Character, Location, CharacterFullInfoDto>
    {
        public CharacterFullInfoDto Map(Character source1, Location source2)
        {
            var characterFullInfoModel = new CharacterFullInfoDto()
            {
                name = source1.Name,
                gender = source1.Gender,
                origin = new CharacterOriginDto()
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
