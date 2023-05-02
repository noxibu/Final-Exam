using Final_Exam___Sales_Management_System.DTOs;
using Final_Exam___Sales_Management_System.Entities;

namespace Final_Exam___Sales_Management_System.Services
{
    public interface IUserInformationService
    {
        void AddUserInformation(Guid userId, UserInformationDto userInformationDto);
        void UpdateUserInformation(Guid id, UserInformationDto userInformation);
        void UpdateUserInformationFirstName(Guid userId, FirstNameDto firstNameDto);
        void UpdateUserInformationLastName(Guid userId, LastNameDto lastNameDto);
        void UpdateUserInformationPersonalCode(Guid userId, PersonalCodeDto personalCodeDto);
        void UpdateUserInformationPhoneNumber(Guid userId, PhoneNumberDto phoneNumberDto);
        void UpdateUserInformationEmail(Guid userId, EmailDto emailDto);
        void DeleteUserInformation(Guid id);
        bool IsUserComplete(Guid userId);
        GetUserInformationDto GetUserInformation(Guid id);
    }
}
