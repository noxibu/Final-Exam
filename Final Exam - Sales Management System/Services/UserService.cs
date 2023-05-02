using Final_Exam___Sales_Management_System.DTOs;
using Final_Exam___Sales_Management_System.Entities;
using Final_Exam___Sales_Management_System.Repositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Final_Exam___Sales_Management_System.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserInformationService _userInformationService;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public string Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(nameof(username));
            }

            if(string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                throw new ArgumentException("Invalid username or password.");
            }

            if(!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                throw new ArgumentException("Invalid username or password");
            }


            return GetJwt(user);
        }

        public User SignUp(string username, string password)
        {
            var existingUser = _userRepository.GetUserByUsername(username);

            if (existingUser != null)
            {
                throw new ArgumentException("Username is already taken.");
            }

            var user = CreateUser(username, password);
            _userRepository.AddUser(user);

            return user;

        }

        private User CreateUser(string username, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = Role.User
            };

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();

            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }


        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);
        }


        private string GetJwt(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(ClaimTypes.Sid, user.Id.ToString())
            };

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signingCredentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;

        }

        public void DeleteUser(Guid userId)
        {
            if(userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            _userRepository.DeleteUser(userId);


        }

        public List<GetUserDto> GetUsers()
        {
            var usersList = _userRepository.GetAllUsers();
            var usersDtoList = new List<GetUserDto>();

            foreach(var user in usersList)
            {
                usersDtoList.Add(new GetUserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    Role = user.Role
                });
            }

            return usersDtoList;
        }

    }
}
