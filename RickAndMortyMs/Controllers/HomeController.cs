using Microsoft.AspNetCore.Mvc;

namespace RickAndMortyMs.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
