using BlogApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BlogApp.Models.ORM.Entity
{
    public class BlogPostComment:Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }

        private bool _isActive = false;
        public bool IsActive { get { return _isActive; } set { _isActive = value; } }


        public int BlogPostID { get; set; }
        [ForeignKey("BlogPostID")]
        public virtual BlogPost BlogPost { get; set; }

    }
}