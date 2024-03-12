using DAL.Context;
using Microsoft.AspNetCore.Mvc;
using OtakuOasis.Interfaces;

namespace OtakuOasis.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IAnimeRepository animeRepository;

        public CategoryController(IAnimeRepository animeRepository)
        {
            this.animeRepository = animeRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        // From Any Badge
        public IActionResult Fillter(int CategoryId)
        {
            ViewBag.CategoryId = CategoryId;
            // all animes with passed categories
            var Animes = animeRepository.GetAnimeByCategory(CategoryId);
            return View(Animes);

        }
    }
}
