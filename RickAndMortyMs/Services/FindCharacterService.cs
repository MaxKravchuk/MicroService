using RickAndMortyMs.Mapper.Interface;
using RickAndMortyMs.Models.Domain;
using RickAndMortyMs.Models.Dto;
using RickAndMortyMs.Repositories.Interfaces;
using RickAndMortyMs.Services.Interfaces;

namespace RickAndMortyMs.Services
{
    public class FindCharacterService : IFindCharacterService
    {
        private readonly IRepository _repository;
        private readonly ITrippleMapper<Character, Location, CharacterFullInfoDto> _rippleMapper;
        public FindCharacterService(
            IRepository repository,
            ITrippleMapper<Character, Location, CharacterFullInfoDto> rippleMapper)
        {
            _repository = repository;
            _rippleMapper = rippleMapper;
        }

        public async Task<IEnumerable<CharacterFullInfoDto>> GetCharacterByName(string name)
        {
            var path1 = $"/character/?name={name}";
            var result = new List<CharacterFullInfoDto>();

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
