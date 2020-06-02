using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Reply
    {
        [Key]
        public int ReplyID { get; set; }

        [Required]
        public string ReplyText { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
