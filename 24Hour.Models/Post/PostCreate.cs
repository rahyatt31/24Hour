using _24Hour.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models.Post
{
    public class PostCreate
    {
        [Required]
        public string PostTitle { get; set; }

        [Required]
        public string PostText { get; set; }
        
        [Required]
        public Data.User PostAuthor { get; set; }
    }
}
