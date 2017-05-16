using BlogApp.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class SiteBaseController : Controller
    {
        public BlogContext db;
        public SiteBaseController()
        {
            db = new BlogContext();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

    }
}