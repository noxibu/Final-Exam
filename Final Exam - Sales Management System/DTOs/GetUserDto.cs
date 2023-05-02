using Final_Exam___Sales_Management_System.Entities;

namespace Final_Exam___Sales_Management_System.DTOs
{
    public class GetUserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
    }
}
