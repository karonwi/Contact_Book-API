using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Model;
using BusinessLogic.Interfaces;
using Data.DTO;
using Data.DTO.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserContact> _userManager;
      

        public UserService(UserManager<UserContact> userManager)
        {
            _userManager = userManager;
           
        }
        public async Task<bool> AddNewContact(RegistrationRequest contact)
        {
           
            if (contact!= null)
            {
                UserMappings.GetUser(contact);
                return true;
            }
            throw new ArgumentException("Invalid Input");

        }

        public async Task<UserResponse> GetUserById(string userId)
        {
            
            UserContact contact = await _userManager.FindByIdAsync(userId);
            if (contact != null)
            {
                return UserMappings.GetUserResponse(contact);
            }

            throw new ArgumentException("Resource not found");
        }

        public async Task<UserResponse> GetUserByEmail(string userEmail)
        {
            var contact = await _userManager.FindByEmailAsync(userEmail);
            if (contact != null)
            {
                return UserMappings.GetUserResponse(contact);
            }
            
            throw new ArgumentException("Resource not found");
        }

        public async Task<List<UserContact>> GetAllUser()
        {
            var contacts = await _userManager.Users.ToListAsync();

            return contacts;
        }

        public async Task<bool> UpdateContactPhoto(string userId,string photo)
        {
            UserContact contact = await _userManager.FindByIdAsync(userId);

            if (contact != null)
            {
                
                contact.ImageUrl = photo;
                var result = await _userManager.UpdateAsync(contact);

                if (result.Succeeded)
                {
                    return true;
                }

                string errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += error.Description + Environment.NewLine;
                }

                throw new MissingFieldException(errors);
            }

            throw new ArgumentException("Resource not found");
        }


        public async Task<bool> UpdateContact(string userId,UpdateUserRequest updateUser)
        {
            UserContact contact = await _userManager.FindByIdAsync(userId);
            if (contact != null)
            {
                
                var result = await _userManager.UpdateAsync(contact);

                if (result.Succeeded)
                {
                    return true;
                }

                string errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += error.Description + Environment.NewLine;
                }

                throw new MissingFieldException(errors);
            }

            throw new ArgumentException("Resource not found");
        }

        public async Task<bool> DeleteContact(string userId)
        {
            var contact = await _userManager.FindByIdAsync(userId);

            if (contact != null)
            {
                await _userManager.DeleteAsync(contact);
                
            }
            throw new ArgumentException("Contact Not found");

        }
    }
}
