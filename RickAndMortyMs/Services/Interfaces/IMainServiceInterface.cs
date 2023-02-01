using RickAndMortyMs.Models.Dto;

namespace RickAndMortyMs.Services.Interfaces
{
    public interface IMainServiceInterface
    {
        Task<bool> CheckCharacterInTheEpisode(string characterName, string episodeName);
        //Task<IEnumerable<CharacterDto>> GetCharacterByName(string characterName);
    }
}
