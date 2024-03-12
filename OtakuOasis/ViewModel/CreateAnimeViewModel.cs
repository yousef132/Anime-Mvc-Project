using Microsoft.AspNetCore.Mvc.Rendering;
using OtakuOasis.Helper;
using OtakuOasis.Validations;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace OtakuOasis.ViewModel
{
	public class CreateAnimeViewModel: AnimeViewModel
    {
        [Required(ErrorMessage = "Image Is Required")]
        [AllowedExtentionsValidation(FileSetting.AllowedExtentions)]
        [FileSizeValidation(FileSetting.MaxFileSizeInBytes)]
        public IFormFile Image { get; set; }
    }
}
