using BlogApp.Areas.Admin.Models;
using BlogApp.Areas.Admin.Models.Services.HTMLDataSourceServices;
using BlogApp.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Areas.Admin.Controllers
{
    public class KararlarController : BaseController
    {
        // GET: Admin/Kararlar
        public ActionResult Index()
        {
            List<KararlarVM> model = db.Kararlars.Where(x => x.IsDeleted == false).Select(x => new KararlarVM()
            {
                Title = x.Title,
                Content = x.Content,
                ID = x.ID,
                CategoryName=x.Category.Name            
            }).ToList();

            return View(model);
        }
        public ActionResult AddKararlar()
        {
            KararlarVM model = new KararlarVM();
            model.drpCategories = DrpServices.getDrpCategries();



            return View(model);
        }
        [ValidateInput(false)]//Ck editörden gelen htmller zararlı olarak engellenmesin diye
        [HttpPost]
        public ActionResult AddKararlar(KararlarVM model)
        {
            KararlarVM vmodel = new KararlarVM();
            vmodel.drpCategories = DrpServices.getDrpCategries();

            if (ModelState.IsValid)
            {
                Kararlar kr = new Kararlar();
                kr.CategoryID = model.CategoryID;
                kr.Title = model.Title;
                kr.Content = model.Content;

                db.Kararlars.Add(kr);
                db.SaveChanges();

                ViewBag.IslemDurum = 1;
                return RedirectToAction("index");

            }
            else
            {
                ViewBag.IslemDurum = 2;
                return View(vmodel);
            }
            
        }
        public ActionResult UpdateKararlar(int id)
        {
            Kararlar kr = db.Kararlars.FirstOrDefault(x => x.ID == id);
            KararlarVM model = new KararlarVM();

            model.CategoryID = kr.CategoryID;
            model.Content = kr.Content;
            model.drpCategories = DrpServices.getDrpCategries();
            model.Title = kr.Title;

            return View(model);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateKararlar(KararlarVM mdl)
        {
            mdl.drpCategories = DrpServices.getDrpCategries();
            if (ModelState.IsValid)
            {
                Kararlar kr = db.Kararlars.FirstOrDefault(x => x.ID == mdl.ID);
                kr.CategoryID = mdl.CategoryID;
                kr.Content = mdl.Content;
                kr.Title = mdl.Title;

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
    }
}