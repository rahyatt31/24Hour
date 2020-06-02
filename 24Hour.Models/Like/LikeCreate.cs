using _24Hour.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models.Like
{
    public class LikeCreate
    {
        [Required]
        public Data.Post LikedPost { get; set; }
        
        [Required]
        public Data.User Liker { get; set; }
    }
}
