using BlogApp.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Models.ORM.Entity
{
    public class SiteMenu:Base
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string cssClass { get; set; }
    }
}