using Final_Exam___Sales_Management_System.Database;
using Final_Exam___Sales_Management_System.Entities;
using Microsoft.EntityFrameworkCore;

namespace Final_Exam___Sales_Management_System.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly SalesDbContext _context;
        public ImageRepository(SalesDbContext context)
        {
            _context = context;
        }
        public async Task<Image> AddAsync(Guid id, Image image)
        {
            await _context.Images.AddAsync(image);

            try
            {
                await _context.SaveChangesAsync();
                return image;
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving image to database", ex);
            }
        }

        public Image GetImage(Guid userInformationId)
        {
            var image = _context.Images.FirstOrDefault(x => x.UserInformationId == userInformationId);
            return image;
        }

        public void DeleteImage(Guid userInformationId)
        {

            var image = GetImage(userInformationId);

            _context.Images.Remove(image);

            try
            {
                _context.SaveChanges();
            } catch(DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
