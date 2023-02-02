using Microsoft.AspNetCore.Mvc;
using RickAndMortyMs.Services.Interfaces;

namespace RickAndMortyMs.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class MainController : ControllerBase
    {
        private readonly ISearchCharacterInEpisodeService searchCharacterInEpisodeService;
        private readonly IFindCharacterService findCharacterService;
        public MainController(
            ISearchCharacterInEpisodeService _searchCharacterInEpisodeService,
            IFindCharacterService _findCharacterService)
        {
            searchCharacterInEpisodeService = _searchCharacterInEpisodeService;
            findCharacterService = _findCharacterService;
        }
        [HttpGet("check-persone")]
        public async Task<IActionResult> Check(string nameC, string nameE)
        {
            try
            {
                if (!await searchCharacterInEpisodeService.CheckCharacterInTheEpisode(nameC, nameE))
                    return Ok((object)$"Character {nameC} did not appear in episode {nameE}");
                return Ok((object)$"Character {nameC} appeared in episode {nameE}");
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }

        [HttpPost("persone")]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {
                var result = await findCharacterService.GetCharacterByName(name);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
            
        }
    }
}
