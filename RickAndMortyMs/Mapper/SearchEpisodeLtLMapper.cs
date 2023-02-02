using RickAndMortyMs.Mapper.Interface;
using RickAndMortyMs.Models.Domain;
using RickAndMortyMs.Models.ViewModel;

namespace RickAndMortyMs.Mapper
{
    public class SearchEpisodeLtLMapper : IEnumerableMapper<IEnumerable<Episode>, IEnumerable<EpisodCheckVM>>
    {
        public IEnumerable<EpisodCheckVM> Map(IEnumerable<Episode> source)
        {
            var episodeChecksModel = source.Select(GetEpisodeCheckModel).ToList();
            return episodeChecksModel;
        }

        private EpisodCheckVM GetEpisodeCheckModel(Episode episode)
        {
            var episodeCheck = new EpisodCheckVM()
            {
                characters = episode.Characters
            };

            return episodeCheck;
        }
    }
}
