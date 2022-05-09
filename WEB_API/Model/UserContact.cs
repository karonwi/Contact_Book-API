using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Identity;

namespace Model
{
    public class UserContact : IdentityUser
    {
        public UserContact()
        {
            Address = new List<Address>();
        }
        [Required(ErrorMessage = "{0} is a mandatory field")]
        [MaxLength(50,ErrorMessage = "The {0} cannot have more than {1} characters")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "{0} is a mandatory field")]
        [MaxLength(50, ErrorMessage = "The {0} cannot have more than {1} characters")]
        public string LastName { get; set; }

        public string Gender { get; set; }

        public string ImageUrl { get; set; }
        public IList<Address> Address { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsAdmin { get; set; }


    }
}
