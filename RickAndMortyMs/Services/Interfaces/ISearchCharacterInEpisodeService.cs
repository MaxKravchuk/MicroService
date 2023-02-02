using RickAndMortyMs.Models.Dto;

namespace RickAndMortyMs.Services.Interfaces
{
    public interface ISearchCharacterInEpisodeService
    {
        Task<bool> CheckCharacterInTheEpisode(string characterName, string episodeName);
    }
}
