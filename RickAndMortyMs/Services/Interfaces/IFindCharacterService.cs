using RickAndMortyMs.Models.ViewModel;

namespace RickAndMortyMs.Services.Interfaces
{
    public interface IFindCharacterService
    {
        Task<IEnumerable<CharacterFullInfoVM>> GetCharacterByName(string name);
    }
}
