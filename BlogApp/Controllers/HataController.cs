using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class HataController : Controller
    {
        [Route("404")]
        public ActionResult Hata()
        {
            return View();
        }
    }
}