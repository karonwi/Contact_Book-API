using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DTO;

namespace BusinessLogic.Interfaces
{
    public interface IAuthentication
    {
        Task<UserResponse> Login(UserRequest userRequest);
        Task<UserResponse> Register(RegistrationRequest regisRequest);
    }
}
