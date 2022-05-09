using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DTO
{
    public class UserRequest
    {
        [Required(ErrorMessage = "{0} is a mandatory field")]
        [MaxLength(50, ErrorMessage = "The {0} cannot have more than {1} characters")]
        [EmailAddress(ErrorMessage = "Input a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is a mandatory field")]
        [MaxLength(50, ErrorMessage = "The {0} cannot have more than {1} characters")]
        public string Password { get; set; }
    }
}
