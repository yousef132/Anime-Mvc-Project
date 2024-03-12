using Microsoft.AspNetCore.Mvc;
using OtakuOasis.Interfaces;
using OtakuOasis.Models;
using System.Diagnostics;

namespace OtakuOasis.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimeRepository animeRepository;

        public HomeController(IAnimeRepository animeRepository)
        {
			this.animeRepository = animeRepository;
		}

        public IActionResult Index()
        {
            var animes = animeRepository.GetAll();
            return View(animes);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
