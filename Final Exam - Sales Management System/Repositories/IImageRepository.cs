using Final_Exam___Sales_Management_System.Entities;

namespace Final_Exam___Sales_Management_System.Repositories
{
    public interface IImageRepository
    {
        Task<Image> AddAsync(Guid id, Image image);
        Image GetImage(Guid userId);

        void DeleteImage(Guid userInformationId);
    }
}
