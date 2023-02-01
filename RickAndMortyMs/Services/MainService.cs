using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Newtonsoft.Json;
using RickAndMortyMs.Models.Domain;
using RickAndMortyMs.Models.Dto;
using RickAndMortyMs.Services.Interfaces;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace RickAndMortyMs.Services
{
    public class MainService : BaseService, IMainServiceInterface
    {
        public async Task<bool> CheckCharacterInTheEpisode(string characterName, string episodeName)
        {
            var path1 = $"?name={characterName}";
            var path2 = $"?name={episodeName}";

            var dto = await GetPages<CharacterCheckDto>($"https://rickandmortyapi.com/api/character/{path1}");
            var chIds = new List<int>();
            foreach (var character in dto)
            {
                chIds.Add(character.id);
            }
            var chIds2 = new List<int>();
            var dto1 = await GetPages<EpisodCheckDto>($"https://rickandmortyapi.com/api/episode/{path2}");
            foreach (var episode in dto1)
            {
                foreach(var x in episode.characters)
                {
                    chIds2.Add(GetId(x));
                }
            }
            
            return chIds.Intersect(chIds2).Any();
        }

        private int GetId(string url)
        {
            string pattern = @"\d+$";
            Match match = Regex.Match(url, pattern);
            if (!match.Success)
            {
                return 0;
            }
            return int.Parse(match.Value);
        }
    }
}
