using Final_Exam___Sales_Management_System.Entities;

namespace Final_Exam___Sales_Management_System.Repositories
{
    public interface IAddressRepository
    {
        public void AddAddress(Address address);

        public void UpdateAddress(Address address);
        public Address GetAddress(Guid userId);
        public void RemoveAddress(Guid id);
    }
}
