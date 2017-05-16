using BlogApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Models.ORM.Entity
{
    public class Kararlar:Base
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}