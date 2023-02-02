using Microsoft.Extensions.Caching.Memory;
using RickAndMortyMs.Services.Interfaces;

namespace RickAndMortyMs.Services
{
    public class CachedSearchCharacterInEpisodeService : ISearchCharacterInEpisodeService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ISearchCharacterInEpisodeService _searchCharacterInEpisodeService;
        private const string CacheKey = "BoolStatmentAboutCharacterAndEpisode";

        public CachedSearchCharacterInEpisodeService(
            IMemoryCache memoryCache,
            ISearchCharacterInEpisodeService searchCharacterInEpisodeService)
        {
            _memoryCache = memoryCache;
            _searchCharacterInEpisodeService = searchCharacterInEpisodeService;
        }

        public async Task<bool> CheckCharacterInTheEpisode(string characterName, string episodeName)
        {
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(3));

            if (_memoryCache.TryGetValue(CacheKey, out bool result))
                return result;

            result = await _searchCharacterInEpisodeService.CheckCharacterInTheEpisode(characterName, episodeName);

            _memoryCache.Set(CacheKey, result, cacheOptions);

            return result;
        }
    }
}