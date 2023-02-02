using RickAndMortyMs.Mapper.Interface;
using RickAndMortyMs.Models.Domain;
using RickAndMortyMs.Models.Dto;

namespace RickAndMortyMs.Mapper
{
    public static class MapperConfiguration
    {
        public static void AddMappers(this IServiceCollection services)
        {
            services.AddScoped<IEnumerableMapper<IEnumerable<Character>, IEnumerable<CharacterCheckDto>>, SearchCharacterLtLMapper>();
            services.AddScoped<IEnumerableMapper<IEnumerable<Episode>, IEnumerable<EpisodCheckDto>>, SearchEpisodeLtLMapper>();
            services.AddScoped<ITrippleMapper<Character, Location, CharacterFullInfoDto>, MapperToFullCharacterInfo>();
        }
    }
}
