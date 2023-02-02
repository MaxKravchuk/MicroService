using Microsoft.Extensions.Caching.Memory;
using RickAndMortyMs.Models.ViewModel;
using RickAndMortyMs.Services.Interfaces;

namespace RickAndMortyMs.Services
{
    public class CachedFindCharacterService : IFindCharacterService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IFindCharacterService _findCharacterService;
        private const string CacheKey = "FullInfoAboutCharacter";

        public CachedFindCharacterService(
            IMemoryCache memoryCache,
            IFindCharacterService findCharacterService)
        {
            _memoryCache = memoryCache;
            _findCharacterService = findCharacterService;
        }

        public async Task<IEnumerable<CharacterFullInfoVM>> GetCharacterByName(string name)
        {
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(3));

            if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<CharacterFullInfoVM> result))
                return result;

            result = await _findCharacterService.GetCharacterByName(name);

            _memoryCache.Set(CacheKey, result, cacheOptions);

            return result;

        }
    }
}