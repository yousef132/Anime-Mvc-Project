using Microsoft.AspNetCore.Mvc;

namespace OtakuOasis.Repositories
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
