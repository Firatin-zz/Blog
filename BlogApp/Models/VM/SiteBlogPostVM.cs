using BlogApp.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Models.VM
{
    public class SiteBlogPostVM
    {
        public int BlogPostID { get; set; }
        public string Title { get; set; }
        public string PostImagePath { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public virtual List<CommentVM> Yorumlar { get; set; }
        public virtual Category Categorys { get; set; }
    }
}