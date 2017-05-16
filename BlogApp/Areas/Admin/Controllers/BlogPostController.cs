using BlogApp.Areas.Admin.Models;
using BlogApp.Areas.Admin.Models.Services.HTMLDataSourceServices;
using BlogApp.Models.ORM.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Areas.Admin.Controllers
{
    public class BlogPostController : BaseController
    {
        public ActionResult Index()
        {
            List<BlogPostVM> model = db.BlogPosts.Where(x => x.IsDeleted == false).OrderByDescending(x => x.ID).Select(x => new BlogPostVM()
            {
                Title = x.Title,
                CategoryName = x.Category.Name,
                ID = x.ID
            }).ToList();

            return View(model);
        }
        public ActionResult AddBlogPost()
        {
            BlogPostVM model = new BlogPostVM();

            //Aşağıdaki 1. yolda dropdownliste kategori çekmeyi yazdık. Sonra bir çok yerde ihtiyacımız olabilir diye Model klasörü içinde services/Html..../DrpServices içerisinde tanımladık ve 2. yol ile çağırdık
            #region 1.yol
            //model.drpCategories = db.Categories.Select(x => new SelectListItem()
            //{
            //    Text = x.Name,
            //    Value = x.ID.ToString()
            //}).ToList();
            #endregion//1.yol
            //2. yol
            model.drpCategories = DrpServices.getDrpCategries();

            return View(model);
        }
        [ValidateInput(false)]//Ck editörden gelen htmller zararlı olarak engellenmesin diye
        [HttpPost]
        public ActionResult AddBlogPost(BlogPostVM model, HttpPostedFileBase PostImage)
        {
            //--dropdownlist 2.yöntem içindir. View döndürülen vmodel buna dahildir.
            BlogPostVM vmodel = new BlogPostVM();
            vmodel.drpCategories = DrpServices.getDrpCategries();


            if (ModelState.IsValid)
            {
                string filename = "";
                foreach (string name in Request.Files)//birden fazla resim seçilmesi durumunda
                {
                    PostImage = Request.Files[name];

                    string ext = Path.GetExtension(PostImage.FileName);
                    if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")//bu formatlarda ise al
                    {
                        string uniqenum = Guid.NewGuid().ToString();//aynı isimli resim gelme ihtimalinden dolayı..
                        filename = uniqenum + PostImage.FileName;//benzersiz uniq isim verdik resme.
                        PostImage.SaveAs(Server.MapPath("~/Areas/Admin/Content/img/BlogPost/" + filename));
                    }

                }

                BlogPost bp = new BlogPost();
                bp.CategoryID = model.CategoryID;
                bp.Title = model.Title;
                bp.Content = model.Content;

                bp.ImagePath = filename;

                db.BlogPosts.Add(bp);
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
        public ActionResult UpdateBlogPost(int id)
        {
            BlogPost bp = db.BlogPosts.FirstOrDefault(x => x.ID == id);//hangi post olduğunu belirliyoruz
            BlogPostVM mdl = new BlogPostVM();//dbden postu çekip içeriği doldurma işlemini yapıyoruz
            mdl.CategoryID = bp.CategoryID;
            mdl.Title = bp.Title;
            mdl.Content = bp.Content;
            mdl.drpCategories = DrpServices.getDrpCategries();
            return View(mdl);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult UpdateBlogPost(BlogPostVM mdl, HttpPostedFileBase PostImage)
        {
            try
            {
                mdl.drpCategories = DrpServices.getDrpCategries();//işlem yapıldıktan sonra droplar dolu gelsin die
                if (ModelState.IsValid)
                {


                    BlogPost bp = db.BlogPosts.FirstOrDefault(x => x.ID == mdl.ID);
                    string filename = "";
                    if (PostImage !=null)
                    {

                        string ext = Path.GetExtension(PostImage.FileName);
                        if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")//bu formatlarda ise al
                        {
                            string uniqenum = Guid.NewGuid().ToString();//aynı isimli resim gelme ihtimalinden dolayı..
                            filename = uniqenum + PostImage.FileName;//benzersiz uniq isim verdik resme.
                            PostImage.SaveAs(Server.MapPath("~/Areas/Admin/Content/img/BlogPost/" + filename));

                        }

                        bp.ImagePath = filename;

                    }
                    else
                    {
                        bp.ImagePath = bp.ImagePath;
                    }
                  
                    bp.CategoryID = mdl.CategoryID;
                    bp.Title = mdl.Title;
                    bp.Content = mdl.Content;

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
        public JsonResult DeleteBlogPost(int id)
        {
            BlogPost bp = db.BlogPosts.FirstOrDefault(x => x.ID == id);
            try
            {
                bp.IsDeleted = true;
                bp.DeleteDate = DateTime.Now;
                db.SaveChanges();
                return Json("OK");

            }
            catch
            {
                return Json("FAIL");
            }
        }
    }
}