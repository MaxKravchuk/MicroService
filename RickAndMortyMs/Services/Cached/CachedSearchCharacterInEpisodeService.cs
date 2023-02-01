using Microsoft.Extensions.Caching.Memory;
using RickAndMortyMs.Models.Dto;
using RickAndMortyMs.Repositories.Interfaces;
using RickAndMortyMs.Services.Interfaces;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace RickAndMortyMs.Services
{
    public class CachedSearchCharacterInEpisodeService : ISearchCharacterInEpisodeService
    {
        private readonly IRepository _repo;
        private readonly IMemoryCache _memoryCache;
        private readonly ISearchCharacterInEpisodeService _searchCharacterInEpisodeService;

        private static readonly Regex _idRegex = new (@"\d+$");
        private const string CacheKey = "ResultKey";

        public CachedSearchCharacterInEpisodeService(
            IRepository repo,
            IMemoryCache memoryCache,
            ISearchCharacterInEpisodeService searchCharacterInEpisodeService)
        {
            _memoryCache = memoryCache;
            _repo = repo;
            _searchCharacterInEpisodeService = searchCharacterInEpisodeService;
        }

        public async Task<bool> CheckCharacterInTheEpisode(string characterName, string episodeName)
        {
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(10))
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(60));

            if (_memoryCache.TryGetValue(CacheKey, out bool result))
                return result;

            result = await _searchCharacterInEpisodeService.CheckCharacterInTheEpisode(characterName, episodeName);

            _memoryCache.Set(CacheKey, result, cacheOptions);

            return result;
        }
    }
}