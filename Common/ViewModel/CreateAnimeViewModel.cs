using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace OtakuOasis.ViewModel
{
	public class CreateAnimeViewModel
	{
        [Required]
        public string Name { get; set; }
        [Required]

        public string Description { get; set; }
        [Required(ErrorMessage = "Image Is Required")]


        public IFormFile Image { get; set; }
        [Required]

        // ids for categories selected by user
        public List<int> categoriesId { get; set; }
        // list<string>categoryname => to print categories name in dropdownlist , send this in asp-items 

        [Required]
        public IEnumerable<SelectListItem> categories { get; set; } = new List<SelectListItem>();



        [Required(ErrorMessage = "Rate Is Required")]
        [Range(0, 10 , ErrorMessage ="Rate Must Be From 0 To 10")]
        public int Rate { get; set; }


        [Required(ErrorMessage = "Number Of Seasons Is Required")]
        [Display(Name = "Number Of Seasons")]
        public int NOSeason { get; set; }


        [Required(ErrorMessage = "Number Of Episods Is Required")]
        [Display(Name = "Number Of Episods")]
        public int NOEpisods { get; set; }

    }
}
