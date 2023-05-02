using Final_Exam___Sales_Management_System.Database;
using Final_Exam___Sales_Management_System.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Security.Cryptography;

namespace Final_Exam___Sales_Management_System.Repositories
{
    public class AddressRepository: IAddressRepository
    {
        private readonly SalesDbContext _context;
        private readonly IUserInformationRepository _userInformationRepository;

        public AddressRepository(SalesDbContext context, IUserInformationRepository userInformationRepository)
        {
            _context = context;
            _userInformationRepository = userInformationRepository;
        }

        public void AddAddress(Address address)
        {
            if (address == null) throw new ArgumentNullException();
            
            _context.Addresses.Add(address);

            try
            {
                _context.SaveChanges();
            } catch (DbUpdateException ex)
            {
                throw new Exception("Error occured while adding user.", ex);
            }


        }

        public Address GetAddress(Guid userId)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);

            if(userInformation == null)
            {
                throw new ArgumentNullException(nameof(userInformation));
            }

            var address = _context.Addresses.FirstOrDefault(x => x.UserInformationId == userInformation.Id);

            return address;
        }

        public void RemoveAddress(Guid userInformationId)
        {

            if (userInformationId == null)
            {
                throw new ArgumentNullException(nameof(userInformationId));
            }

            var address = _context.Addresses.FirstOrDefault(x => x.UserInformationId == userInformationId);

            _context.Addresses.Remove(address);

            try
            {
                _context.SaveChanges();

            } 
            catch(DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateAddress(Address address)
        {
            if (address == null)
            {
                throw new ArgumentException(nameof(address));
            }

            var existingAddress = _context.Addresses.FirstOrDefault(x => x.Id == address.Id);

            existingAddress.Street = address.Street;
            existingAddress.City = address.City;
            existingAddress.HouseNumber = address.HouseNumber;
            existingAddress.ApartmentNumber = address.ApartmentNumber;


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
