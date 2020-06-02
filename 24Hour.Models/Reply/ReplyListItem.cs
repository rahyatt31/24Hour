using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models.Reply
{
    public class ReplyListItem
    {
        public int ReplyID { get; set; }
        public string ReplyTitle { get; set; }
        public string ReplyText { get; set; }
        public Guid UserID { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
