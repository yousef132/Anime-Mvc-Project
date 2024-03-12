using Microsoft.AspNetCore.Mvc;
using OtakuOasis.Interfaces;
using OtakuOasis.Models;
using System.Diagnostics;

namespace OtakuOasis.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAnimeRepository animeRepository;
        private readonly ICategoryRepository categoryRepository;

        public HomeController(IAnimeRepository animeRepository,
            ICategoryRepository categoryRepository
            )
        {
			this.animeRepository = animeRepository;
            this.categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Categories = categoryRepository.GetAllCategories();
            var animes = animeRepository.GetAll();
            return View(animes);
        }
        public IActionResult GetAnimeBasedOnCategoreis(int CategoryId)
        {
            ViewBag.CategoryId = CategoryId;
            if (CategoryId == 0)
            {
                return PartialView(animeRepository.GetAll());
            }
            var tmp = animeRepository.GetAnimeByCategory(CategoryId);
            return PartialView(tmp);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
