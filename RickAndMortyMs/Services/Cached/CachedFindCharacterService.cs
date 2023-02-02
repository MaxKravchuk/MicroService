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

        public async Task<IEnumerable<CharacterFullInfoDto>> GetCharacterByName(string name)
        {
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(3));

            if (_memoryCache.TryGetValue(CacheKey, out IEnumerable<CharacterFullInfoDto> result))
                return result;

            result = await _findCharacterService.GetCharacterByName(name);

            _memoryCache.Set(CacheKey, result, cacheOptions);

            return result;

        }
    }
}