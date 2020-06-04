using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Like
    {
        [Key]
        public int LikeID { get; set; }

        [Required]
        public Post LikedPost { get; set; }

        [ForeignKey("Liker")]
        public Guid UserID { get; set; }
        public virtual Profile Liker { get; set; }

        [ForeignKey("Post")]
        public int PostID { get; set; }
        public virtual Post Post { get; set; }

        [ForeignKey("Comment")]
        public int CommentID { get; set; }
        public virtual Comment Comment { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
