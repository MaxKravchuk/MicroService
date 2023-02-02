using RickAndMortyMs.Mapper.Interface;
using RickAndMortyMs.Models.Domain;
using RickAndMortyMs.Models.Dto;
using RickAndMortyMs.Repositories.Interfaces;
using RickAndMortyMs.Services.Interfaces;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RickAndMortyMs.Services
{
    public class SearchCharacterInEpisodeService : ISearchCharacterInEpisodeService
    {
        private readonly IRepository _repo;
        private readonly IEnumerableMapper<IEnumerable<Character>, IEnumerable<CharacterCheckDto>> _mapperCharacter;
        private readonly IEnumerableMapper<IEnumerable<Episode>, IEnumerable<EpisodCheckDto>> _mapperEpisode;
        private static readonly Regex _idRegex = new (@"\d+$");

        public SearchCharacterInEpisodeService(
            IRepository repo,
            IEnumerableMapper<IEnumerable<Character>, IEnumerable<CharacterCheckDto>> mC,
            IEnumerableMapper<IEnumerable<Episode>, IEnumerable<EpisodCheckDto>> mE)
        {
            _repo = repo;
            _mapperCharacter = mC;
            _mapperEpisode = mE;
        }

        public async Task<bool> CheckCharacterInTheEpisode(string characterName, string episodeName)
        {
            var path1 = $"/character/?name={characterName}";
            var path2 = $"/episode/?name={episodeName}";

            var characters = await _repo.GetPages<Character>(path1);
            var episodes = await _repo.GetPages<Episode>(path2);

            var charactedCheck = _mapperCharacter.Map(characters);
            var episodeCheck = _mapperEpisode.Map(episodes);

            var characterIds = new HashSet<int>();
            var episodeIds = new HashSet<int>();

            foreach (var character in charactedCheck)
            {
                characterIds.Add(character.id);
            }

            foreach (var episode in episodeCheck)
            {
                foreach (var item in episode.characters)
                {
                    episodeIds.Add(GetId(item));
                }
            }

            var result = characterIds.Intersect(episodeIds).Any();

            return result;
        }

        private static int GetId(string url)
        {
            Match match = _idRegex.Match(url);
            if (!match.Success)
            {
                return 0;
            }

            return int.TryParse(match.Value, out int id) ? id : 0;
        }
    }
}