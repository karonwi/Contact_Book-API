using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Model;
using Model;

namespace Data.DTO
{
    public class RegistrationRequest
    {
        [Required(ErrorMessage = "FirstName is a mandatory field")]
        [MaxLength(50, ErrorMessage = "The {0} cannot have more than {1} characters")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "{0} is a mandatory field")]
        [MaxLength(50, ErrorMessage = "The {0} cannot have more than {1} characters")]
        public string LastName { get; set; }


        [EmailAddress(ErrorMessage = "Input a valid email address")] 
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
        
        public string UserName { get; set; }


    }
}
