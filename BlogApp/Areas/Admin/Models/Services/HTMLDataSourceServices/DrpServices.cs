using BlogApp.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Areas.Admin.Models.Services.HTMLDataSourceServices
{
    public class DrpServices
    {
        public static IEnumerable<SelectListItem> getDrpCategries()
        {
            using (BlogContext db = new BlogContext())
            {
                IEnumerable<SelectListItem> drpCategories = db.Categories.Select(x => new SelectListItem()
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                }).ToList();
                return drpCategories;
            }

        }
    }
}