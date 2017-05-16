using BlogApp.Areas.Admin.Models;
using BlogApp.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Areas.Admin.Controllers
{
    public class SiteMenuController : BaseController
    {
        public ActionResult AddSiteMenu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSiteMenu(SiteMenuVM model)
        {
            SiteMenu sm = new SiteMenu();
            sm.Name = model.Name;
            sm.Url = model.Url;
            sm.cssClass = model.cssClass;

            db.SiteMenus.Add(sm);
            db.SaveChanges();
            ViewBag.IslemDurum = 1;
            return View();
        }
        public ActionResult AddSiteMenuwithJSON()
        {
            return View();//jqury ile sayfa post edilmeden insert için kullanıldı. AddSiteMenuJSON actiona post ediyoruz
        }
        public JsonResult AddSiteMenuJSON(SiteMenuVM model)
        {
            SiteMenu sm = new SiteMenu();//jquery ile gelenleri db ekliyoruz.
            sm.Name = model.Name;
            sm.Url = model.Url;
            sm.cssClass = model.cssClass;

            db.SiteMenus.Add(sm);
            db.SaveChanges();

            return Json("");
        }
    }
}