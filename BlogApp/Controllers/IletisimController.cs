using BlogApp.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class IletisimController : Controller
    {
        // GET: Iletisim
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Iletisim(Iletisim model)
        {
            if (ModelState.IsValid)
            {
                //var body = new StringBuilder();
                //body.AppendLine("İsim: " + model.FullName);
                //body.AppendLine("Tel: " + model.Phone);
                //body.AppendLine("EPosta: " + model.Email);
                //body.AppendLine("Konu: " + model.Message);

                //Gmail.SendMail(body.ToString());
                ViewBag.Durum = 1;
                return PartialView(ViewBag.Durum);
            }
            else
            {
                
                ViewBag.Durum = 2;
                return PartialView(ViewBag.Durum);
            }

        }
    }
}