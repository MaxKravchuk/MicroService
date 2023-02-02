using Newtonsoft.Json;
using RickAndMortyMs.Models.Dto.Pageing;
using RickAndMortyMs.Repositories.Exeptions;
using RickAndMortyMs.Repositories.Interfaces;
using System.Text.RegularExpressions;

namespace RickAndMortyMs.Repositories
{
    public class Repository : IRepository
    {
        private HttpClient HttpClient { get; }
        private readonly IConfiguration _configuration;
        private readonly string _baseAddress;
        private readonly Regex PagePattern = new ("page=(?<pagenr>[0-9]+)");

        public Repository(IConfiguration configuration)
        {
            HttpClient = new HttpClient();
            _configuration = configuration;
            _baseAddress = _configuration["BaseAddress"];
        }

        public async Task<T> Get<T>(string path)
        {
            string pathr;
            if (!path.Contains(_baseAddress))
            {
                pathr = _baseAddress + path;
            }
            else
            {
                pathr = path;
            }
            var response = await HttpClient.GetAsync(pathr);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(result);
        }

        public async Task<IEnumerable<T>> GetPages<T>(string url)
        {
            var result = new List<T>();
            var nextPage = -1;

            do
            {
                var dto = await Get<PageDto<T>>(nextPage == -1 ? url : $"{url}{(url.Contains('?') ? '&' : '?')}page={nextPage}");
                if (dto?.Results != null)
                {
                    result.AddRange(dto.Results);
                }
                else
                {
                    throw new NotFoundException("Character or episode does not found!");
                }

                nextPage = GetNextPageNumber(dto.Info.Next);
            }
            while (nextPage != -1);

            return result;
        }

        private int GetNextPageNumber(string url)
        {
            if (String.IsNullOrEmpty(url))
                return -1;

            var result = PagePattern.Match(url).Groups["pagenr"].Value;

            if (String.IsNullOrEmpty(result))
                return -1;

            return Convert.ToInt32(result);
        }
    }
}
