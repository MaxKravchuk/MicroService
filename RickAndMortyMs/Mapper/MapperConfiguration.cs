using RickAndMortyMs.Mapper.Interface;
using RickAndMortyMs.Models.Domain;
using RickAndMortyMs.Models.ViewModel;

namespace RickAndMortyMs.Mapper
{
    public static class MapperConfiguration
    {
        public static void AddMappers(this IServiceCollection services)
        {
            services.AddScoped<IEnumerableMapper<IEnumerable<Character>, IEnumerable<CharacterCheckVM>>, SearchCharacterLtLMapper>();
            services.AddScoped<IEnumerableMapper<IEnumerable<Episode>, IEnumerable<EpisodCheckVM>>, SearchEpisodeLtLMapper>();
            services.AddScoped<ITrippleMapper<Character, Location, CharacterFullInfoVM>, MapperToFullCharacterInfo>();
        }
    }
}
