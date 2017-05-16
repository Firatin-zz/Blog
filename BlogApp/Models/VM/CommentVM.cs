using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogApp.Models.VM
{
    public class CommentVM
    {
        public string Name { get; set; }
        public string EMail { get; set; }
        [Display(Name = "Yorum")]
        public string Content { get; set; }
        public int BlogPostID { get; set; }
    }
}