using _24Hour.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models.Comment
{
    public class CommentEdit
    {
        public int CommentID { get; set; }

        public string CommentText { get; set; }
        public Guid UserID { get; set; }

        public Data.Post CommentPost { get; set; }

       
    }
}
