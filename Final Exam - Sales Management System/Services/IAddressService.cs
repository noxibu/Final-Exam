using Final_Exam___Sales_Management_System.DTOs;

namespace Final_Exam___Sales_Management_System.Services
{
    public interface IAddressService
    {
        public void AddAddress(Guid userId, AddressDto address);
        public AddressDto GetAddress(Guid userId);
        public void UpdateAddress(Guid userId, AddressDto address);
        public void UpdateAddressCity(Guid userId, CityDto cityDto);
        public void UpdateAddressStreet(Guid userId, StreetDto streetDto);
        public void UpdateAddressHouseNumber(Guid userId, HouseNumberDto houseNumberDto);
        public void UpdateAddressApartmentNumber(Guid userId, ApartmentNumberDto apartmentNumberDto);
        public void RemoveAddress(Guid id);
    }
}
