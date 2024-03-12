using BLL.Interfaces;
using DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext context;

		public IAnimeRepository AnimeRepository { get ;set; }
        public ICategoryRepository CategoryRepository { get; set; }

        public UnitOfWork(AppDbContext context,
			IAnimeRepository animeRepository,
			ICategoryRepository categoryRepository

			)
        {
			this.context = context;
			AnimeRepository = animeRepository;
			CategoryRepository = categoryRepository;

            
        }

		public void Complete()
		{
			context.SaveChanges();
		}
	}
}
