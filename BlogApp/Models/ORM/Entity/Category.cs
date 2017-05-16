using BlogApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogApp.Models.ORM.Entity
{
    public class Category:Base
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<BlogPost> BlogPost { get; set; }
    }
}