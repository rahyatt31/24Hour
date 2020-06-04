using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models.Profile
{
    public class ProfileCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        //[Required]
        //public Guid UserID { get; set; } -- This is generated when the ApplicationUser is entered into dbo
 
    }
}
