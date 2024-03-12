using DAL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OtakuOasis.ViewModel;
using OtakuOasis.Interfaces;
using OtakuOasis.Repositories;
using OtakuOasis.Entities;
namespace OtakuOasis.Controllers
{
    public class AnimeController : Controller
    {
        private readonly IAnimeRepository animeRepository;
        private readonly ICategoryRepository categoryRepository;

        public AnimeController(IAnimeRepository animeRepository,
            ICategoryRepository categoryRepository
            )
        {
            this.animeRepository = animeRepository;
            this.categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var animes = animeRepository.GetAll();
            return View(animes);
        }

        public IActionResult Create()
        {

            CreateAnimeViewModel createAnimeViewModel = new CreateAnimeViewModel()
            {
                categories = categoryRepository.GetSelectList()
            };
            return View(createAnimeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAnimeViewModel model)
        {

            //server side validation
            if (!ModelState.IsValid)
            {

                model.categories = categoryRepository.GetSelectList();
                return View(model);

            }

            //save anime in database

           await animeRepository.CreateAnime(model);


            //save image in server
            return RedirectToAction(nameof(Index));

        }


        public IActionResult Details(int id)
        {

            Anime anime = animeRepository.GetById(id);
            if (anime is null)
            {
                return NotFound();
            }
            return View(anime);
        }
       // [HttpDelete]
        public IActionResult Delete(int id)
        {
            Anime anime = animeRepository.GetById(id);
            if (anime is null)
            {
                return NotFound();
            }
            animeRepository.Delete(anime);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int id)
        {
            Anime anime = animeRepository.GetById(id);
            if (anime is null)
                return NotFound();

            UpdateAnimeViewModel model = new UpdateAnimeViewModel()
            {
                Id = id,
                Name= anime.Name,
                Description=anime.Description,
                Rate = anime.Rate,
                NOEpisods=anime.NOEpisods,
                NOSeason=anime.NOSeason,
                SelectedCategories=anime.AnimeCategories.Select(a=>a.CategoryId).ToList(),
                categories=categoryRepository.GetSelectList(),
                CurrentImage = anime.Image,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateAnimeViewModel model)
        {

            //server side validation
            if (!ModelState.IsValid)
            {

                model.categories = categoryRepository.GetSelectList();
                return View(model);

            }

            //save anime in database

            var anime = await animeRepository.Update(model);

            if (anime is null)
                return BadRequest();

            //save image in server
            return RedirectToAction(nameof(Index));

        }

    }
}
