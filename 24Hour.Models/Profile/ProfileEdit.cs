using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models.Profile
{
   public class ProfileEdit
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid UserID { get; set; }
    }
}
