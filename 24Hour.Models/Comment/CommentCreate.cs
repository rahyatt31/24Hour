﻿using _24Hour.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models.Comment
{
    public class CommentCreate
    {
       
        [Required]
        public string CommentText { get; set; }
        public Guid UserID { get; set; }
        public int PostID { get; set; }
        [Required]
        public Data.Post CommentPost { get; set; }


    }
}
