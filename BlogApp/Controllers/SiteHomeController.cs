using BlogApp.Models.ORM.Entity;
using BlogApp.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class SiteHomeController : SiteBaseController
    {
        // GET: SiteHome
        public ActionResult Index()
        {
            var Postlar = db.BlogPosts.Where(x => x.IsDeleted == false).OrderByDescending(x => x.ID).Take(4).ToList();
            return View();
        }
        public ActionResult _SonEklenenler()
        {
            var Postlar = db.BlogPosts.Where(x => x.IsDeleted == false).OrderByDescending(x => x.ID).Take(4).ToList();
            return View(Postlar);
        }
        public ActionResult _Hakkimda()
        {
            var hakkimda = db.Hakkimdas.FirstOrDefault();
            return View(hakkimda);
        }
        public ActionResult HeaderPartial()
        {
            List<Category> model = db.Categories.Where(x => x.IsDeleted == false).ToList();
            return PartialView("~/Views/Shared/Partial/HeaderPartial.cshtml", model);
        }
        //[Route("iletisim")]
        public ActionResult Iletisim()
        {
            var hak = db.Hakkimdas.FirstOrDefault();
            return View(hak);
        }
        public ActionResult _SonKararlar()
        {
            var model = db.Kararlars.Where(x => x.IsDeleted == false).Take(5).OrderByDescending(x => x.ID).ToList();

            return View(model);
        }
        [Route("hakkimda")]
        public ActionResult Hakkimda()
        {
            var hakkimda = db.Hakkimdas.FirstOrDefault();
            return View(hakkimda);
        }
    }
}