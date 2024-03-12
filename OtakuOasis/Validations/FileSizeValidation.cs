using System.ComponentModel.DataAnnotations;

namespace OtakuOasis.Validations
{
    public class FileSizeValidation : ValidationAttribute
    {
        private readonly int maxSize;
        public FileSizeValidation(int maxSize)
        {
            this.maxSize = maxSize;

        }
        protected override ValidationResult IsValid(object? value,
            ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > maxSize)
                {
                    return new ValidationResult($"Max Size Is 1 MB");
                }
            }
            return ValidationResult.Success;

        }
    }
}
