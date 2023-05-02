namespace Final_Exam___Sales_Management_System.DTOs
{
    public class UserInformationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public AddressDto Address { get; set; }
    }
}
