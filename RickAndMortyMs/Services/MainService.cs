using Newtonsoft.Json;
using RickAndMortyMs.Models.Domain;
using RickAndMortyMs.Models.Dto;
using RickAndMortyMs.Services.Interfaces;
using System.IO;
using System.Reflection;
using System.Xml.Linq;


namespace RickAndMortyMs.Services
{
    public class MainService : BaseService, IMainServiceInterface
    {
        public async Task<bool> CheckCharacterInTheEpisode(string characterName, string episodeName)
        {
            var path1 = $"?name={characterName}";
            var path2 = $"?name={episodeName}";

            var dto = await GetPages<Character>($"https://rickandmortyapi.com/api/character/{path1}");
            var dto1 = await GetPages<EpisodDto>($"https://rickandmortyapi.com/api/episode/{path2}");
            return true;
        }
    }
}
