using BlogApp.Areas.Admin.Models;
using BlogApp.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            List<CategoryVM> model = db.Categories.Where(x => x.IsDeleted == false).Select(x => new CategoryVM()
            {
                Name = x.Name,
                Description = x.Description,
                ID = x.ID
            }).OrderByDescending(x => x.ID).ToList();
            return View(model);
        }
        //Kategorinin viewda gösterilecek kısmıdır
        public ActionResult AddCategory()
        {
            return View();
        }
        //Kategorinin eklenme işleminde çalışacak kısmıdır.Yani butona tıklandıgında burası calısacak
        [HttpPost]
        public ActionResult AddCategory(CategoryVM model)
        {
            if (ModelState.IsValid)
            {
                Category cate = new Category();//instance aldık
                cate.Name = model.Name;
                cate.Description = model.Description;

                db.Categories.Add(cate);//categoriyeEkle
                db.SaveChanges();//dbye gönder
                ViewBag.IslemDurum = 1;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View();
            }

        }
        public JsonResult DeleteCategory(int id)
        {
            Category cate = db.Categories.FirstOrDefault(x => x.ID == id);

            try
            {
                cate.IsDeleted = true;
                cate.DeleteDate = DateTime.Now;
                db.SaveChanges();

                return Json("OK");
            }
            catch
            {

                return Json("FAIL");
            }
        }
        public ActionResult UpdateCategory(int id)
        {//güncellenecek kategoriyi bulup verileri ekrana yazdırma
            Category cate = db.Categories.FirstOrDefault(x => x.ID == id);
            CategoryVM model = new CategoryVM();
            model.Name = cate.Name;
            model.Description = cate.Description;
            return View(model);
        }
        [HttpPost]
        public ActionResult UpdateCategory(CategoryVM model)
        {
            //guncellencek kategori buraya gönderilir ve update edilir.
            if (ModelState.IsValid)
            {
                Category cat = db.Categories.FirstOrDefault(x => x.ID == model.ID);
                cat.Name = model.Name;
                cat.Description = model.Description;
                db.SaveChanges();
                ViewBag.IslemDurum = 1;
                return View();
            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View();
            }

        }
    }
}