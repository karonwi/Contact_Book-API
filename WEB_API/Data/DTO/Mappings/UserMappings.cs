using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Model;
using Model;

namespace Data.DTO.Mappings
{
    public class UserMappings
    {
        public static UserContact GetUser(RegistrationRequest request)
        {
            return new UserContact
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = string.IsNullOrWhiteSpace(request.UserName) ? request.Email : request.UserName,
                //Gender = string.Equals("male", request.Gender.ToLower()) ? request.Gender = "male": request.Gender = "female",
                PhoneNumber = request.PhoneNumber
            };
        }

        public static UserResponse GetUserResponse(UserContact contact)
        {
            return new UserResponse
            {
                Email = contact.Email,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                PhoneNumber = contact.PhoneNumber,
                Id = contact.Id
            };
        }
    }
}
