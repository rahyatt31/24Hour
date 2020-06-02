using _24Hour.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models.Comment
{
    public class CommentDetail
    {
        
        public int CommentID { get; set; }

        public string CommentText { get; set; }
        public Data.User CommentAuthor { get; set; }

        public Data.Post CommentPost { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        
  
    }
}
