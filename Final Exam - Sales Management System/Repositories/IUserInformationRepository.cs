using Final_Exam___Sales_Management_System.DTOs;
using Final_Exam___Sales_Management_System.Entities;

namespace Final_Exam___Sales_Management_System.Repositories
{
    public interface IUserInformationRepository
    {
        void AddInformation(UserInformation userInformation);
        void UpdateInformation(Guid userId, UserInformation userInformationDto);
        void DeleteInformation(Guid userId);

        UserInformation GetUserInfo(Guid id);


    }
}
