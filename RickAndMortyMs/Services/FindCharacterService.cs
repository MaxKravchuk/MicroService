using RickAndMortyMs.Mapper.Interface;
using RickAndMortyMs.Models.Domain;
using RickAndMortyMs.Models.ViewModel;
using RickAndMortyMs.Repositories.Interfaces;
using RickAndMortyMs.Services.Interfaces;

namespace RickAndMortyMs.Services
{
    public class FindCharacterService : IFindCharacterService
    {
        private readonly IRepository _repository;
        private readonly ITrippleMapper<Character, Location, CharacterFullInfoVM> _rippleMapper;
        public FindCharacterService(
            IRepository repository,
            ITrippleMapper<Character, Location, CharacterFullInfoVM> rippleMapper)
        {
            _repository = repository;
            _rippleMapper = rippleMapper;
        }

        public async Task<IEnumerable<CharacterFullInfoVM>> GetCharacterByName(string name)
        {
            var path1 = $"/character/?name={name}";
            var result = new List<CharacterFullInfoVM>();

            var character = await _repository.GetPages<Character>(path1);
            foreach (var origin in character)
            {
                var location = await _repository.Get<Location>(origin.Origin.Url);
                var fullModel = _rippleMapper.Map(origin, location);
                result.Add(fullModel);
            }
            return result;
        }
    }
}
