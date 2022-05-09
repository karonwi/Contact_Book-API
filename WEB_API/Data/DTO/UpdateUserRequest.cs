using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Model;

namespace Data.DTO
{
    public class UpdateUserRequest
    {
        [Required(ErrorMessage = "{0} is a mandatory field")]
        [MaxLength(50, ErrorMessage = "The {0} cannot have more than {1} characters")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "{0} is a mandatory field")]
        [MaxLength(50, ErrorMessage = "The {0} cannot have more than {1} characters")]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string ImageUrl { get; set; }

        
    }
}
