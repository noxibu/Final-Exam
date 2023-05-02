namespace Final_Exam___Sales_Management_System.Entities
{
    public class UserInformation
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Image ProfilePicture { get; set; }
        public Address Address { get; set; }
    }
}
