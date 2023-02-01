using Microsoft.AspNetCore.Mvc;
using RickAndMortyMs.Services.Interfaces;

namespace RickAndMortyMs.Controllers
{
    [ApiController]
    [Route("api/v1/check-person")]
    public class MainController : ControllerBase
    {
        private readonly ISearchCharacterInEpisodeService mainInterface;
        public MainController(ISearchCharacterInEpisodeService _mainInterface)
        {
            mainInterface = _mainInterface;
        }
        [HttpGet]
        public async Task<IActionResult> Check(string nameC, string nameE)
        {
            try
            {
                if (!await mainInterface.CheckCharacterInTheEpisode(nameC, nameE))
                    return Ok((object)$"Character {nameC} did not appear in episode {nameE}");
                return Ok((object)$"Character {nameC} appeared in episode {nameE}");
            }
            catch (Exception ex)
            {
                return StatusCode(404, ex.Message);
            }
        }
    }
}
