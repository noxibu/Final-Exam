using Final_Exam___Sales_Management_System.Attributes;

namespace Final_Exam___Sales_Management_System.DTOs
{
    public class ImageUploadDto
    {
        [MaxFileSize(20000*20000)]
        [AllowedExtensions(new string[] { ".png", ".jpg" })]
        public IFormFile Image { get; set; }
    }
}
