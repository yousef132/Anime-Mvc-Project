using DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace OtakuOasis.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext context;

        public CategoryController(AppDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        // From Any Badge
        public IActionResult Fillter(int CategoryId)
        {
            var Anime = context.animes.GetByCategoryId();

        }
    }
}
