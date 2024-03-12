using DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace OtakuOasis.Entities
{

	public class Anime: BaseEntity
	{

		[MaxLength(400)]
		public string Description { get; set; }
		[Range(0,5)]
		public int Rate {  get; set; }
		[Display(Name="Number Of Seasons")]
		public int NOSeason {  get; set; }
		[Display(Name = "Number Of Episods")]
		public int NOEpisods {  get; set; }

		public string Image {  get; set; }
        public ICollection<AnimeCategory> AnimeCategories { get; set; }
    }
}
