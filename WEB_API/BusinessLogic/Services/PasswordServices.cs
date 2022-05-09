using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Data;
using Data.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Model;

namespace BusinessLogic.Services
{
    public class PasswordServices
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly UserManager<UserContact> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ImailService _mailService;

        public PasswordServices(ITokenGenerator tokenGenerator, UserManager<UserContact> userManager, IConfiguration configuration, ImailService mailService)
        {
            _tokenGenerator = tokenGenerator;
            _userManager = userManager;
            _configuration = configuration;
            _mailService = mailService;
        }

        public async Task<UserResponse> ResetPassword(ResetPasswordDTO resetPassword)
        {
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user == null)
            {
                return new UserResponse
                {
                    Success = false,
                    Message = "Password reset unsuccessful"
                };
            }

            var result = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.NewPassword);

            if (result.Succeeded)
            {
                return new UserResponse
                {
                    Success = true,
                    Message = "Password reset successful"
                };
            }

            return new UserResponse
            {
                Success = true,
                Message = "errors"
            };
        }

        public async Task<UserResponse> ForgotPassword(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return new UserResponse
                    {
                        Success = false,
                        Message = "Invalid Email"
                    };

                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                string url = $"{_configuration["AppDomain"]}/ResetPassword?email={email}&token={token}";

                var mailRequest = new MailRequest()
                {
                    ToEmail = user.Email,
                    Subject = "Reset Password",
                    Body = ""
                };

                await _mailService.SendEmailAsync(mailRequest);
                return new UserResponse
                {
                    Success = true,
                    Message = "Password reset successful"
                };
            }
            catch (Exception )
            {
                return new UserResponse
                {
                    Success = false,
                    Message = "Password reset unsuccessful"
                };
            }

        }
    }
}
