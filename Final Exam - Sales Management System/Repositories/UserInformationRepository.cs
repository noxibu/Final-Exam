using Final_Exam___Sales_Management_System.Database;
using Final_Exam___Sales_Management_System.DTOs;
using Final_Exam___Sales_Management_System.Entities;
using Final_Exam___Sales_Management_System.Services;
using Microsoft.EntityFrameworkCore;

namespace Final_Exam___Sales_Management_System.Repositories
{
    public class UserInformationRepository: IUserInformationRepository
    {

        private readonly SalesDbContext _context;
        private readonly IImageService _imageService;
        private readonly IAddressService _addressService;


        public UserInformationRepository(SalesDbContext context)
        {
            _context = context;
        }

        public void AddInformation(UserInformation userInformation)
        {
            if(userInformation == null)
            {
                throw new ArgumentException(nameof(userInformation));
            }

            _context.UsersInformation.Add(userInformation);
            try
            {
                _context.SaveChanges();
            } catch(DbUpdateException ex)
            {
                throw new Exception("Error adding user information.", ex);
            }
        }



        public void DeleteInformation(Guid userId)
        {
            var userInformation = _context.UsersInformation.FirstOrDefault(x => x.UserId == userId);

            if(userInformation == null)
            {
                throw new Exception("User information is not present");
            }


            _context.UsersInformation.Remove(userInformation);

            try
            {
                _context.SaveChanges();
            } catch(DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public UserInformation GetUserInfo(Guid id)
        {
            return _context.UsersInformation.FirstOrDefault(x => x.UserId == id);
        }

        public void UpdateInformation(Guid userId, UserInformation userInformation)
        {
            if (userInformation == null)
            {
                throw new ArgumentException(nameof(userInformation));
            }

            var existingInfo = _context.UsersInformation.FirstOrDefault(x => x.Id == userInformation.Id);

            existingInfo.FirstName = userInformation.FirstName;
            existingInfo.LastName = userInformation.LastName;
            existingInfo.PersonalCode = userInformation.PersonalCode;
            existingInfo.PhoneNumber = userInformation.PhoneNumber;
            existingInfo.Email = userInformation.Email;


            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error updating user information.", ex);
            }
        }
    }
}
