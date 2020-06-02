using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models.Reply
{
    public class ReplyEdit
    {
        public int ReplyID { get; set; }
        public string ReplyTitle { get; set; }
        public string ReplyText { get; set; }
        public Guid UserID { get; set; }
    }
}
