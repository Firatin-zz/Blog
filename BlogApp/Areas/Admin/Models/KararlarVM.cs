using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Areas.Admin.Models
{
    public class KararlarVM:BaseVM
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<SelectListItem> drpCategories { get; set; }
    }
}