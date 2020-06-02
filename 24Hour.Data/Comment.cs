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
        public int CommentID { get; set; }
        public string CommentText { get; set; }
        public User CommentAuthor { get; set; }
        public Post CommentPost { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey("Like")]
        public Like LikedID { get; set; }

        [ForeignKey("Reply")]
        public Reply ReplyID { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
