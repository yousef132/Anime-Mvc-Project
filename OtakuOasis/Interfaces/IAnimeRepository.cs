using OtakuOasis.Entities;
using OtakuOasis.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtakuOasis.Interfaces
{
    public interface IAnimeRepository
    {
        public IEnumerable<Anime> GetAll();
        public Task CreateAnime(CreateAnimeViewModel model);

        public Anime? GetById (int id);
        public void Delete(Anime anime);

        public Task<Anime?> Update (UpdateAnimeViewModel model);

    }
}
