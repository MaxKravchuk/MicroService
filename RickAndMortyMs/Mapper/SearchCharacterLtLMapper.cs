using RickAndMortyMs.Mapper.Interface;
using RickAndMortyMs.Models.Domain;
using RickAndMortyMs.Models.ViewModel;

namespace RickAndMortyMs.Mapper
{
    public class SearchCharacterLtLMapper : IEnumerableMapper<IEnumerable<Character>, IEnumerable<CharacterCheckVM>>
    {
        public IEnumerable<CharacterCheckVM> Map(IEnumerable<Character> source)
        {
            var characterChecksModel = source.Select(GetCharacterCheckModel).ToList();
            return characterChecksModel;
        }

        private CharacterCheckVM GetCharacterCheckModel(Character character)
        {
            var characterCheck = new CharacterCheckVM()
            {
                id= character.Id,
            };

            return characterCheck;
        }
    }
}
