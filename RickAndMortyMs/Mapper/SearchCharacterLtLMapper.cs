using RickAndMortyMs.Mapper.Interface;
using RickAndMortyMs.Models.Domain;
using RickAndMortyMs.Models.Dto;

namespace RickAndMortyMs.Mapper
{
    public class SearchCharacterLtLMapper : IEnumerableMapper<IEnumerable<Character>, IEnumerable<CharacterCheckDto>>
    {
        public IEnumerable<CharacterCheckDto> Map(IEnumerable<Character> source)
        {
            var characterChecksModel = source.Select(GetCharacterCheckModel).ToList();
            return characterChecksModel;
        }

        private CharacterCheckDto GetCharacterCheckModel(Character character)
        {
            var characterCheck = new CharacterCheckDto()
            {
                id= character.Id,
            };

            return characterCheck;
        }
    }
}
