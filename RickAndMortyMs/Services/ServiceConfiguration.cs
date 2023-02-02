using RickAndMortyMs.Services.Interfaces;

namespace RickAndMortyMs.Services
{
    public static class ServiceConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ISearchCharacterInEpisodeService, SearchCharacterInEpisodeService>();
            services.AddScoped<IFindCharacterService, FindCharacterService>();
            services.Decorate<ISearchCharacterInEpisodeService, CachedSearchCharacterInEpisodeService>();
            services.Decorate<IFindCharacterService, CachedFindCharacterService>();
        }
    }
}
