using BlogApp.Models.ORM.Entity;
using BlogApp.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class SiteKararlarController : SiteBaseController
    {
        // GET: Kararlar
        public ActionResult Index(string title, int id)
        {
            Kararlar kr = db.Kararlars.FirstOrDefault(x => x.ID == id);
            SiteKararlarVM model = new SiteKararlarVM();
            model.CategoryName = kr.Category.Name;
            model.Content = kr.Content;
            model.Title = kr.Title;

            return View(model);
        }
        [ValidateInput(false)]
        public ActionResult KararlarCategori(int id)
        {
            List<Kararlar> model = db.Kararlars.Where(x => x.CategoryID == id).OrderByDescending(x => x.ID).ToList();
            return View(model);
        }
    }
}