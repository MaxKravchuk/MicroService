using RickAndMortyMs.Models.Dto;

namespace RickAndMortyMs.Services.Interfaces
{
    public interface IFindCharacterService
    {
        Task<IEnumerable<CharacterFullInfoDto>> GetCharacterByName(string name);
    }
}
