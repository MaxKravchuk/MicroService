using Newtonsoft.Json;
using RickAndMortyMs.Models.Dto.Pageing;
using System.Text.RegularExpressions;

namespace RickAndMortyMs.Services
{
    public class BaseService
    {
        private HttpClient _httpClient;
        static readonly Regex PagePattern = new Regex("page=(?<pagenr>[0-9]+)");

        public BaseService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://rickandmortyapi.com/")
            };
        }

        public async Task<T> Get<T>(string path)
        {
            var response = await _httpClient.GetAsync(path);
            return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
        }

        public async Task<IEnumerable<T>> GetPages<T>(string url)
        {
            var result = new List<T>();
            var nextPage = -1;

            do
            {
                var dto = await Get<PageDto<T>>(nextPage == -1 ? url : $"{url}{(url.Contains("?") ? "&" : "?")}page={nextPage}");
                result.AddRange(dto.Results);

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
