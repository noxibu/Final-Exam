using Final_Exam___Sales_Management_System.DTOs;
using Final_Exam___Sales_Management_System.Entities;

namespace Final_Exam___Sales_Management_System.Services
{
    public interface IUserService
    {
        User SignUp(string username, string password);
        string Login(string username, string password);

        void DeleteUser(Guid userId);

        List<GetUserDto> GetUsers();
    }
}
