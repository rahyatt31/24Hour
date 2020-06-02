using _24Hour.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models.Like
{
    public class LikeCreate
    {
        public int PostID { get; set; }
        public Guid UserID { get; set; }
    }
}
