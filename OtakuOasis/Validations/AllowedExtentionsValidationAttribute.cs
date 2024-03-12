using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OtakuOasis.Validations
{
    public class AllowedExtentionsValidationAttribute:ValidationAttribute
    {
        private readonly string _allowedExtentions;
        public AllowedExtentionsValidationAttribute(string allowedExtentions)
        {
            _allowedExtentions = allowedExtentions;
            
        }
        protected override ValidationResult IsValid(object? value,
            ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);

                bool isallowed = _allowedExtentions.Split(',').
                    Contains(extention,StringComparer.OrdinalIgnoreCase);

                if(!isallowed)
                {
                    return new ValidationResult($"Only {_allowedExtentions}  Are Allowed!");
                }
            }
            return ValidationResult.Success;

        }
    }
}
