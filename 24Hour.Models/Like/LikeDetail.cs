using _24Hour.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models.Like
{
    public class LikeDetail
    {
        public int LikeID { get; set; }
        public Data.Post LikedPost { get; set; }
        public Data.User Liker { get; set; }
        
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        
        [Display(Name="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
