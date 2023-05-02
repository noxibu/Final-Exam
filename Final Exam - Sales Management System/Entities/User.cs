namespace Final_Exam___Sales_Management_System.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Role Role { get; set; }
        public UserInformation UserInformation { get; set; }
    }

    public enum Role
    {
        Admin, 
        User
    }
}
