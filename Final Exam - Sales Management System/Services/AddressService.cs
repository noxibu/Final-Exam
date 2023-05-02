using Final_Exam___Sales_Management_System.DTOs;
using Final_Exam___Sales_Management_System.Entities;
using Final_Exam___Sales_Management_System.Repositories;

namespace Final_Exam___Sales_Management_System.Services
{
    public class AddressService: IAddressService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserInformationRepository _userInformationRepository;
        private readonly IAddressRepository _addressRepository;

        public AddressService(IUserRepository userRepository, IUserInformationRepository userInformationRepository, IAddressRepository addressRepository)
        {
            _userRepository = userRepository;
            _userInformationRepository = userInformationRepository;
            _addressRepository = addressRepository;
        }

        public void AddAddress(Guid userId, AddressDto addressDto)
        {
            var user = _userRepository.GetUserById(userId);

            if (user == null) { throw new ArgumentNullException(nameof(user)); }

            var userInformation = _userInformationRepository.GetUserInfo(user.Id);

            if (userInformation == null) { throw new ArgumentNullException(nameof(userInformation)); }

            Console.WriteLine();

            var addressInfo = new Address
            {
                Id = Guid.NewGuid(),
                City = addressDto.City,
                Street = addressDto.Street,
                HouseNumber = addressDto.HouseNumber,
                ApartmentNumber = addressDto.ApartmentNumber,
                UserInformationId = userInformation.Id

            };

            _addressRepository.AddAddress(addressInfo);
        }

        public AddressDto GetAddress(Guid userId)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);

            if(userInformation == null)
            {
                throw new ArgumentNullException();
            }

            var address = _addressRepository.GetAddress(userId);

            var addressDto = new AddressDto
            {
                City = address.City,
                Street = address.Street,
                HouseNumber = address.HouseNumber,
                ApartmentNumber = address.ApartmentNumber
            };

            return addressDto;


        }

        public void RemoveAddress(Guid userId)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);
            if (userInformation == null)
            {
                throw new ArgumentNullException(nameof(userInformation));
            }

            _addressRepository.RemoveAddress(userInformation.Id);
        }

        public void UpdateAddress(Guid userId, AddressDto addressDto)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);

            if (userInformation == null)
            {
                throw new ArgumentNullException(nameof(userInformation));
            }

            var address = _addressRepository.GetAddress(userId);


            address.City = addressDto.City;
            address.Street = addressDto.Street;
            address.HouseNumber = addressDto.HouseNumber;
            address.ApartmentNumber = addressDto.ApartmentNumber;

            _addressRepository.UpdateAddress(address);
        }

        public void UpdateAddressApartmentNumber(Guid userId, ApartmentNumberDto apartmentNumberDto)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);

            if (userInformation == null)
            {
                throw new ArgumentNullException(nameof(userInformation));
            }

            var address = _addressRepository.GetAddress(userId);


            address.ApartmentNumber = apartmentNumberDto.ApartmentNumber;
            _addressRepository.UpdateAddress(address);
        }

        public void UpdateAddressCity(Guid userId, CityDto cityDto)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);

            if (userInformation == null)
            {
                throw new ArgumentNullException(nameof(userInformation));
            }

            var address = _addressRepository.GetAddress(userId);


            address.City = cityDto.City;
            _addressRepository.UpdateAddress(address);
        }

        public void UpdateAddressHouseNumber(Guid userId, HouseNumberDto houseNumberDto)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);

            if (userInformation == null)
            {
                throw new ArgumentNullException(nameof(userInformation));
            }

            var address = _addressRepository.GetAddress(userId);


            address.HouseNumber = houseNumberDto.HouseNumber;
            _addressRepository.UpdateAddress(address);
        }

        public void UpdateAddressStreet(Guid userId, StreetDto streetDto)
        {
            var userInformation = _userInformationRepository.GetUserInfo(userId);

            if (userInformation == null)
            {
                throw new ArgumentNullException(nameof(userInformation));
            }

            var address = _addressRepository.GetAddress(userId);


            address.Street = streetDto.Street;
            _addressRepository.UpdateAddress(address);
        }
    }
}
