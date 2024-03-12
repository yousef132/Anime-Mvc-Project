using OtakuOasis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class AnimeCategory
    {
        public int AnimeId { get; set; }
        public Anime Anime { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
