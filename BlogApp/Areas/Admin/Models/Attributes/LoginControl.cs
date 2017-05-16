using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Areas.Admin.Models.Attributes
{
    public class LoginControl:ActionFilterAttribute
    {
        //Herhangi biri url'den admin sayfalarına girmek isterse giriş sayfasına atması için attribute belirliyoruz. 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                filterContext.HttpContext.Response.Redirect("/Admin/Login/Index");
        }
    }
}