using OtakuOasis.Helper;
using OtakuOasis.Validations;
using System.ComponentModel.DataAnnotations;

namespace OtakuOasis.ViewModel
{
    public class UpdateAnimeViewModel: AnimeViewModel
    {
        public string? CurrentImage { get; set; }   
        public int Id { get; set; }
        [AllowedExtentionsValidation(FileSetting.AllowedExtentions)]
        [FileSizeValidation(FileSetting.MaxFileSizeInBytes)]
        public IFormFile? Image { get; set; }
    }
}
