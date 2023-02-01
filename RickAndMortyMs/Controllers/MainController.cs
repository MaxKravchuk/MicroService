using Microsoft.AspNetCore.Mvc;
using RickAndMortyMs.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace RickAndMortyMs.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class MainController : ControllerBase
    {
        private readonly IMainServiceInterface mainInterface;
        public MainController(IMainServiceInterface _mainInterface)
        {
            mainInterface = _mainInterface;
        }
        [HttpGet]
        public async Task<IActionResult> Check(string nameC, string nameE)
        {
            if (!await mainInterface.CheckCharacterInTheEpisode(nameC, nameE))
                return Ok((object)"No");
            return Ok((object)"Yes");
        }
    }
}
