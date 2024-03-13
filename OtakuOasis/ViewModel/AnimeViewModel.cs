using Microsoft.AspNetCore.Mvc.Rendering;
using OtakuOasis.Helper;
using OtakuOasis.Validations;
using System.ComponentModel.DataAnnotations;

namespace OtakuOasis.ViewModel
{
    public class AnimeViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        

        [Required(ErrorMessage = "Select Atleast One Category")]
        // ids for categories selected by user
        public List<int> SelectedCategories { get; set; }

        [Required]
        // All Categories
        public IEnumerable<SelectListItem> categories { get; set; } = new List<SelectListItem>();


        [Required(ErrorMessage = "Rate Is Required")]
        [Range(0, 5, ErrorMessage = "Rate Must Be From 0 To 5")]
        public int Rate { get; set; }


        [Required(ErrorMessage = "Number Of Seasons Is Required")]
        [Display(Name = "Number Of Seasons")]
        public int NOSeason { get; set; }


        [Required(ErrorMessage = "Number Of Episods Is Required")]
        [Display(Name = "Number Of Episods")]
        public int NOEpisods { get; set; }
    }
}
