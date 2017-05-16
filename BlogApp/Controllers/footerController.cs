using BlogApp.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class footerController : SiteBaseController
    {
        // GET: footer
        public ActionResult _Footer()//shared içinde footer var oraya homecontrollerdan modeller gönderildi. fakat daha derli toplu olsun diye bu yöntemi denedim. Daha hoş oldu :)
        {
            return View();
        }
        public ActionResult _iletisim()
        {
            var model = db.Hakkimdas.FirstOrDefault();
            return View(model);
        }
        public ActionResult _Category()
        {
            List<Category> model = db.Categories.Where(x => x.IsDeleted == false).ToList();
            return View(model);
        }
    }
}