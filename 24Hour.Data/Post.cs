using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("PostAuthor")]
        public Guid UserID { get; set; }
        public virtual User PostAuthor { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual ICollection<Like> Like { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }


        // Could work with USER Class
    }
}
