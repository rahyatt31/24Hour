using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models.Reply
{
    public class ReplyCreate
    {
        [Required]
        public string ReplyTitle { get; set; }
        [Required]
        public string ReplyText { get; set; }
        public Guid UserID { get; set; }
    }
}
