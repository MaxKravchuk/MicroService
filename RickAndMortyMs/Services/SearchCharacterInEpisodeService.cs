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
        private static readonly Regex _idRegex = new Regex(@"\d+$");

        public SearchCharacterInEpisodeService(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> CheckCharacterInTheEpisode(string characterName, string episodeName)
        {
            var path1 = $"/character/?name={characterName}";
            var path2 = $"/episode/?name={episodeName}";

            var dto = await _repo.GetPages<CharacterCheckDto>(path1);
            var dto1 = await _repo.GetPages<EpisodCheckDto>(path2);

            var chIds = new HashSet<int>();
            var chIds2 = new HashSet<int>();

            foreach (var character in dto)
            {
                chIds.Add(character.id);
            }

            foreach (var episode in dto1)
            {
                foreach (var x in episode.characters)
                {
                    chIds2.Add(await GetId(x));
                }
            }

            return chIds.Intersect(chIds2).Any();
        }

        private async Task<int> GetId(string url)
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