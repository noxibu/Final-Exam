using Final_Exam___Sales_Management_System.DTOs;
using Final_Exam___Sales_Management_System.Entities;
using Final_Exam___Sales_Management_System.Repositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Final_Exam___Sales_Management_System.Services
{
    public class UserInformationService: IUserInformationService
    {
        private readonly IUserInformationRepository _userInformationRepository;
        private readonly IAddressService _addressService;
        private readonly IImageService _imageService; 

        public UserInformationService(IUserInformationRepository userInformationRepository, 
            IAddressService addressService,
            IImageService imageService)
        {
            _userInformationRepository = userInformationRepository;
            _addressService = addressService;
            _imageService = imageService;
        }

        public void AddUserInformation(Guid userId, UserInformationDto userInformationDto)
        {
            var userInformation = new UserInformation
            {
                Id = Guid.NewGuid(),
                FirstName = userInformationDto.FirstName,
                LastName = userInformationDto.LastName,
                PhoneNumber = userInformationDto.PhoneNumber,
                Email = userInformationDto.Email,
                PersonalCode = userInformationDto.PersonalCode,
                UserId = userId
            };



            _userInformationRepository.AddInformation(userInformation);
            _addressService.AddAddress(userId, userInformationDto.Address);
        }

        public void UpdateUserInformation(Guid userId, UserInformationDto userInformationDto)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);

            if (userInformation == null)
            {
                throw new ArgumentNullException(nameof(userInformation));
            }

            userInformation.FirstName = userInformationDto.FirstName;
            userInformation.LastName = userInformationDto.LastName;
            userInformation.PersonalCode= userInformationDto.PersonalCode;
            userInformation.PhoneNumber= userInformationDto.PhoneNumber;
            userInformation.Email = userInformationDto.Email;
            
            _userInformationRepository.UpdateInformation(userId, userInformation);
        }


        public void DeleteUserInformation(Guid id)
        {
            if(id == null)
            {
                throw new ArgumentNullException();
            }

            var image = _imageService.GetImage(id);
            var address = _addressService.GetAddress(id);
            if (image != null)
            {
                _imageService.DeleteImage(id);
            }

            if (address != null)
            {
                _addressService.RemoveAddress(id);
            }

            _userInformationRepository.DeleteInformation(id);

        }

        public GetUserInformationDto GetUserInformation(Guid userId)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);
            var userImage = _imageService.GetImage(userId);
            var userAddress = _addressService.GetAddress(userId);

            if(userInformation == null)
            {
                throw new ArgumentNullException();
            }

            var userInformationDto = new GetUserInformationDto
            {
                FirstName = userInformation.FirstName,
                LastName = userInformation.LastName,
                PersonalCode = userInformation.PersonalCode,
                PhoneNumber = userInformation.PhoneNumber,
                Email = userInformation.Email,
                Image = userImage,
                Address = userAddress
            };

            return userInformationDto;
        }

        public void UpdateUserInformationFirstName(Guid userId, FirstNameDto firstNameDto)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);
            if (userInformation == null)
            {
                throw new ArgumentNullException(nameof(userInformation));
            }

            userInformation.FirstName = firstNameDto.FirstName;

            _userInformationRepository.UpdateInformation(userId, userInformation);
        }

        public void UpdateUserInformationLastName(Guid userId, LastNameDto lastNameDto)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);
            if (userInformation == null)
            {
                throw new ArgumentNullException(nameof(userInformation));
            }

            userInformation.LastName = lastNameDto.LastName;

            _userInformationRepository.UpdateInformation(userId, userInformation);
        }

        public void UpdateUserInformationPersonalCode(Guid userId, PersonalCodeDto personalCodeDto)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);
            if (userInformation == null)
            {
                throw new ArgumentNullException(nameof(userInformation));
            }

            userInformation.PersonalCode = personalCodeDto.PersonalCode;

            _userInformationRepository.UpdateInformation(userId, userInformation);
        }

        public void UpdateUserInformationPhoneNumber(Guid userId, PhoneNumberDto phoneNumberDto)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);
            if (userInformation == null)
            {
                throw new ArgumentNullException(nameof(userInformation));
            }

            userInformation.PhoneNumber = phoneNumberDto.PhoneNumber;

            _userInformationRepository.UpdateInformation(userId, userInformation);
        }

        public void UpdateUserInformationEmail(Guid userId, EmailDto emailDto)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);
            if (userInformation == null)
            {
                throw new ArgumentNullException(nameof(userInformation));
            }

            userInformation.Email = emailDto.Email;

            _userInformationRepository.UpdateInformation(userId, userInformation);
        }

        public bool IsUserComplete(Guid userId)
        {
            try
            {
                var userInformation = _userInformationRepository.GetUserInfo(userId);
                var userAddress = _addressService.GetAddress(userId);
                var userImage = _imageService.GetImage(userId);

                return true;
            }
            catch
            {
                throw new Exception("Complete registration by adding user info, address and image first.");
                
            }

        }
    }
}
