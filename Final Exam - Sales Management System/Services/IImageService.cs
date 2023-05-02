using Final_Exam___Sales_Management_System.DTOs;
using Final_Exam___Sales_Management_System.Entities;

namespace Final_Exam___Sales_Management_System.Services
{
    public interface IImageService
    {
        Task<Image> AddImageAsync(Guid id, ImageUploadDto imageUploadDto);
        ImageDto GetImage(Guid userId);
        void DeleteImage(Guid userId);
    }
}
