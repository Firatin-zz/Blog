using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Models.VM
{
    public class SiteKararlarVM
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}