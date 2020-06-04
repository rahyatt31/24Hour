using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        [Required]
        public string CommentText { get; set; }
        [Required]
        public Post CommentPost { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey("CommentAuthor")]
        public Guid UserID { get; set; }
        public virtual Profile CommentAuthor { get; set; }

        [ForeignKey("Post")]
        public int PostID { get; set; }
        public virtual Post Post { get; set; }

        public virtual ICollection<Like> Like { get; set; }
        public virtual ICollection<Reply> Reply { get; set; }
    }
}
