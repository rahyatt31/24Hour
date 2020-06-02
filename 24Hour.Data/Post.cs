using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Post
    {   
        [Key]
        public int PostID { get; set; }
        [Required]
        public string PostTitle { get; set; }
        [Required]
        public string PostText { get; set; }
        [Required]
        public User PostAuthor { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        // Could work with USER Class
    }
}
