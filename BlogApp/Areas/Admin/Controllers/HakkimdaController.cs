using BlogApp.Areas.Admin.Models;
using BlogApp.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Areas.Admin.Controllers
{
    public class HakkimdaController : BaseController
    {
        // GET: Admin/Iletisim
        public ActionResult UpdateHakkimda()
        {
            var model = db.Hakkimdas.FirstOrDefault();
            HakkimdaVM vm = new HakkimdaVM();
            vm.Title = model.Title;
            vm.Bilgilerim = model.Bilgilerim;
            vm.Adres = model.Adres;
            vm.Telefon = model.Telefon;
            vm.Email = model.Email;

            return View(vm);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateHakkimda(HakkimdaVM mdl)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    string filename = "";
                    string ext = Path.GetExtension(mdl.PostImage.FileName);
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")//bu formatlarda ise al
                    {
                        string uniqenum = Guid.NewGuid().ToString();//aynı isimli resim gelme ihtimalinden dolayı..
                        filename = uniqenum + mdl.PostImage.FileName;//benzersiz uniq isim verdik resme.
                        mdl.PostImage.SaveAs(Server.MapPath("~/Areas/Admin/Content/img/BlogPost/" + filename));
                    }

                    Hakkimda hk = db.Hakkimdas.FirstOrDefault();
                    hk.Title = mdl.Title;
                    hk.Bilgilerim = mdl.Bilgilerim;
                    hk.ImagePath = filename;
                    hk.Adres = mdl.Adres;
                    hk.Telefon = mdl.Telefon;
                    hk.Email = mdl.Email;

                    db.SaveChanges();
                    ViewBag.IslemDurum = 1;
                    return View(mdl);


                }
                else
                {
                    ViewBag.IslemDurum = 2;
                    return View(mdl);
                }
            }
            catch (Exception)
            {

                ViewBag.IslemDurum = 2;
                return View(mdl);
            }

        }
    }
}