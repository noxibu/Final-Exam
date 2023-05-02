using Final_Exam___Sales_Management_System.Database;
using Final_Exam___Sales_Management_System.Entities;
using Microsoft.EntityFrameworkCore;

namespace Final_Exam___Sales_Management_System.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly SalesDbContext _context;
        public UserRepository(SalesDbContext context)
        {
            _context = context;
        }


        public void AddUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentException(nameof(user));
            }
            _context.Users.Add(user);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error occured while adding user.", ex);
            }

        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

        public User GetUserById(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void DeleteUser(Guid userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            if(user == null)
            {
                throw new Exception("User with this ID doesn't exist.");
            }

            _context.Users.Remove(user);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<User> GetAllUsers()
        {
            var users = _context.Users.ToList();

            return users;
        }
    }
}
