using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Data.DTO;
using Data.DTO.Mappings;
using Microsoft.AspNetCore.Identity;
using Model;

namespace BusinessLogic.Services
{
    public class Authentication : IAuthentication
    {
        private readonly UserManager<UserContact> _userManager;
        private readonly ITokenGenerator _tokenGenerator;

        public Authentication(UserManager<UserContact> userManager, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<UserResponse> Login(UserRequest userRequest)
        {
            UserContact contact = await _userManager.FindByEmailAsync(userRequest.Email);
            if (contact != null)
            {
                if (await _userManager.CheckPasswordAsync(contact,userRequest.Password))
                {
                    var response = UserMappings.GetUserResponse(contact);
                    response.Token = _tokenGenerator.GenerateToken(contact);
                    return response;
                }

                throw new AccessViolationException("invalid credentials");
            }

            throw new AccessViolationException("Invalid Credentials");
        }

        public async Task<UserResponse> Register(RegistrationRequest registrationRequest)
        {
            UserContact contact = UserMappings.GetUser(registrationRequest);
            IdentityResult result = await _userManager.CreateAsync(contact, registrationRequest.Password);
            /*IdentityResult resultChecked =
                await _userManager.CreateAsync(contact, registrationRequest.PasswordConfirmation);*/
            if (result.Succeeded )
            {
                return UserMappings.GetUserResponse(contact);
            }
            string errors = string.Empty;
            foreach (var error in result.Errors)
            {
                errors += error.Description + Environment.NewLine;
            }

            throw new MissingFieldException(errors);
        }
    }
}
