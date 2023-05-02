using Final_Exam___Sales_Management_System.Entities;

namespace Final_Exam___Sales_Management_System.Repositories
{
    public interface IUserRepository
    {

        void AddUser(User user);
        User GetUserByUsername(string username);
        User GetUserById(Guid id);

        void DeleteUser(Guid userId);

        List<User> GetAllUsers();

    }
}
