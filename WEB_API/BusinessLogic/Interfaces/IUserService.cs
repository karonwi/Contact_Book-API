using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DTO;
using Model;

namespace BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<bool> AddNewContact(RegistrationRequest contact);
        Task<UserResponse> GetUserById(string userId);
        
        Task<bool> UpdateContactPhoto(string userId, string photo);
        Task<UserResponse> GetUserByEmail(string userEmail);
        Task<List<UserContact>> GetAllUser();

        Task<bool> UpdateContact(string userId, UpdateUserRequest updateUser);

        Task<bool> DeleteContact(string userId);

    }
}
