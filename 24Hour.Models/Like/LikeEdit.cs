using _24Hour.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models.Like
{
    public class LikeEdit
    {
        public int LikeID { get; set; }
        public Data.Post LikedPost { get; set; }
        public Data.User Liker { get; set; }
    }
}
