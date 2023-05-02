namespace Final_Exam___Sales_Management_System.Entities
{
    public class Address
    {
        public Guid Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public Guid UserInformationId { get; set; }
        public UserInformation UserInformation { get; set; }
    }
}
