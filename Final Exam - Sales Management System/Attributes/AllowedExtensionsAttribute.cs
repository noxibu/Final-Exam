using System.ComponentModel.DataAnnotations;

namespace Final_Exam___Sales_Management_System.Attributes
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _allowedExtentions;
        public AllowedExtensionsAttribute(string[] allowedExtentions)
        {
            _allowedExtentions = allowedExtentions;
        }

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                if (!_allowedExtentions.Contains(extension.ToLower()))
                {
                    return new ValidationResult("Unsupported Media Type");
                }
            }
            return ValidationResult.Success;
        }
    }
}
