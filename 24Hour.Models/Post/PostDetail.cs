using _24Hour.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models.Post
{
    public class PostDetail
    { 
        public int PostID { get; set; }
        public string PostTitle { get; set; }
        public string PostText { get; set; }
        public Data.User PostAuthor { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
