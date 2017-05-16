using BlogApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogApp.Models.ORM.Entity
{
    public class BlogPost:Base
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public int CategoryID { get; set; }
        public string ImagePath { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Category Category { get; set; }
        public virtual List<BlogPostComment> BlogPostComment { get; set; }
    }
}