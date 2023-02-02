using RickAndMortyMs.Mapper.Interface;
using RickAndMortyMs.Models.Domain;
using RickAndMortyMs.Models.Dto;

namespace RickAndMortyMs.Mapper
{
    public class SearchEpisodeLtLMapper : IEnumerableMapper<IEnumerable<Episode>, IEnumerable<EpisodCheckDto>>
    {
        public IEnumerable<EpisodCheckDto> Map(IEnumerable<Episode> source)
        {
            var episodeChecksModel = source.Select(GetEpisodeCheckModel).ToList();
            return episodeChecksModel;
        }

        private EpisodCheckDto GetEpisodeCheckModel(Episode episode)
        {
            var episodeCheck = new EpisodCheckDto()
            {
                characters = episode.Characters
            };

            return episodeCheck;
        }
    }
}
