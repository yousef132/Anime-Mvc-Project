using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using OtakuOasis.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimeCategory>().HasKey(x => new
            {
                x.CategoryId,
                x.AnimeId
            });

            modelBuilder.Entity<Category>()
           .HasData(new Category[]
           {
                new Category { Id = 1, Name = "Shoujo" },
                new Category { Id = 2, Name = "Seinen" },
                new Category { Id = 3, Name = "Josei" },
                new Category { Id = 4, Name = "Ecchi" },
                new Category { Id = 5, Name = "Harem" },
                new Category { Id = 6, Name = "Isekai" },
                new Category { Id = 7, Name = "Mecha" },
                new Category { Id = 8, Name = "Kodomomuke" },
                new Category { Id = 9, Name = "Iyashikei" }
           });
        }
        public DbSet<Anime> animes { get; set; }
        public DbSet<AnimeCategory> AnimeCategories { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}
