using BLL.Interfaces;
using DAL.Context;
using OtakuOasis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class AnimeRepository : GenericRepository<Anime>, IAnimeRepository
    {
		public AnimeRepository(AppDbContext context) : base(context)
		{

		}
    }
}
