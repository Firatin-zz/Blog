using BlogApp.Areas.Admin.Models;
using BlogApp.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogApp.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {

        BlogContext db = new BlogContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (db.AdminUsers.Any(x => x.EMail == model.Email && x.Password == model.Password && x.IsDeleted == false))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);// eger modelden gelen gibi bir kullanıcı varsa cookide tut
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}