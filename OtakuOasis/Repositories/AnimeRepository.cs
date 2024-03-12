using DAL.Context;
using DAL.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using OtakuOasis.Entities;
using OtakuOasis.Helper;
using OtakuOasis.Interfaces;
using OtakuOasis.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtakuOasis.Repositories
{
    public class AnimeRepository : IAnimeRepository
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly string imagesPath;


        public AnimeRepository(AppDbContext context,
            IWebHostEnvironment webHostEnvironment) 
		{
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
            // generate images path (go to wwwroot folder)
            imagesPath = $"{webHostEnvironment.WebRootPath}{FileSetting.ImagesPath}";

        }
        public IEnumerable<Anime> GetAll() => context.animes.Include(a=>a.AnimeCategories).ThenInclude(a=>a.Category).ToList();

        public async Task CreateAnime(CreateAnimeViewModel model)
        {


            Anime anime = new Anime()
            {
                Name = model.Name,
                Description = model.Description,
                Rate = model.Rate,
                NOEpisods = model.NOEpisods,
                NOSeason = model.NOSeason,
                Image= await SaveImage(model.Image),
                // This will insert into animecategory table  {current anime id , categoriesId }
                AnimeCategories = model.SelectedCategories.Select(c => new AnimeCategory
                {
                    CategoryId = c
                }).ToList()
            };
            context.Add(anime);
            context.SaveChanges();
        }

        public Anime? GetById(int id) => context.animes.Include(a=>a.AnimeCategories).ThenInclude(a=>a.Category).FirstOrDefault(a => a.Id == id);

        public void Delete(Anime anime)
        {
            context.animes.Remove(anime);
            var image = Path.Combine(imagesPath, anime.Image);
            File.Delete(image);
            context.SaveChanges();
        }

        public async Task<Anime?> Update(UpdateAnimeViewModel model)
        {
            Anime anime = GetById(model.Id);

            if (anime == null)
                return null;

            bool HasNewImage = model.Image is not null;
            var OldImage = anime.Image;




            anime.NOEpisods = model.NOEpisods;
            anime.NOSeason = model.NOSeason;
            anime.Name = model.Name;
            anime.Description = model.Description;
            anime.Rate = model.Rate;
            anime.AnimeCategories = model.SelectedCategories.Select(d => new AnimeCategory { CategoryId = d }).ToList();

            if (HasNewImage)
                anime.Image = await SaveImage(model.Image!);



            int Affected = context.SaveChanges();

            if(Affected> 0)
            {
                if (HasNewImage)
                {
                   var  image = Path.Combine(imagesPath, OldImage);
                    File.Delete(image);
                }
            }
            return anime;



        }

        private async Task<string> SaveImage(IFormFile Image)
        {
            //Generate Unique Name =>{Unique value}{Image Extention} {File Name}
            var imagename = $"{Guid.NewGuid()}{Path.GetExtension(Image.FileName)}";
            // generate path
            var path = Path.Combine(imagesPath, imagename);

            // saving image in server 
            using var stream = File.Create(path);
            await Image.CopyToAsync(stream);
            return imagename;
        }

        public IEnumerable<Anime> GetAnimeByCategory(int categoryId)
             => GetAll().Where(a => a.AnimeCategories.Any(ac => ac.CategoryId == categoryId));

        //public IEnumerable<Anime> GetAnimeByCategory(int categoryId)
        //{
        //    var f = context.AnimeCategories.Where(x => x.CategoryId == 21).ToList();
        //    //.Include(x => x.Anime);

        //     var s = f.Select(x => x.Anime).ToList();


        //      return s;

        //}


    }
}
