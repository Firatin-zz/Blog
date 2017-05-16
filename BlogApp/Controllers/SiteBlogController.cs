using BlogApp.Models.ORM.Entity;
using BlogApp.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class SiteBlogController : SiteBaseController
    {
        // GET: SiteBlog
        public ActionResult Index(string title, int id)//url'de title'da gözüksün diye title ekledik.İD zaten makeleyi cagırmak için var
        {
            BlogPost bp = db.BlogPosts.Where(x=>x.IsDeleted==false).FirstOrDefault(x => x.ID == id);
            SiteBlogPostVM model = new SiteBlogPostVM();
            model.Title = bp.Title;
            model.Content = bp.Content;
            model.PostImagePath = bp.ImagePath;
            model.Category = bp.Category.Name;
            model.BlogPostID = bp.ID;

            return View(model);
        }
        [HttpPost]
        public ActionResult AddComment(CommentVM model)
        {
            BlogPostComment cmt = new BlogPostComment();
            cmt.Content = model.Content;
            cmt.BlogPostID = model.BlogPostID;
            cmt.Name = model.Name;
            cmt.Email = model.EMail;

            db.BlogPostComments.Add(cmt);
            db.SaveChanges();

            return RedirectToAction("Index", "SiteBlog", new { id = model.BlogPostID });
        }
        [ValidateInput(false)]
        public ActionResult CategoryGetir(string Name, int id)
        {
            List<BlogPost> model = db.BlogPosts.Where(x => x.CategoryID == id).OrderByDescending(x => x.ID).ToList();
            return View(model);
        }
        //[ValidateInput(false)]
        //public ActionResult KararlarCategori(int id)
        //{
        //    List<Kararlar> model = db.Kararlars.Where(x => x.CategoryID == id).OrderByDescending(x => x.ID).ToList();
        //    return View(model);
        //}
        public PartialViewResult LatestPost()
        {
            List<BlogPost> model = db.BlogPosts.Where(x => x.IsDeleted == false).OrderByDescending(x => x.ID).Take(5).ToList();

            return PartialView(model);
        }

    }
}