using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BlogApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapMvcAttributeRoutes();
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            //makale açıldıgında urlde baslık ve id gözüksün diye ayarlama dinamik. title ve id controllerdan geliyor
            routes.MapRoute(
               name: "BlogHaber",
               url: "Blog/{title}/{id}",
               defaults: new { controller = "SiteBlog", action = "Index", title = UrlParameter.Optional, id = UrlParameter.Optional });

            //Kararlar Detay
            routes.MapRoute(
               name: "KararlarDetay",
               url: "Kararlar/{title}/{id}",
               defaults: new { controller = "SiteKararlar", action = "Index", title = UrlParameter.Optional, id = UrlParameter.Optional });

            //Kararlar Kategoriler 
            routes.MapRoute(
               name: "KararlarKategori",
               url: "YargitayKararlari/{Name}/{id}",
               defaults: new { controller = "SiteKararlar", action = "KararlarCategori", Name = UrlParameter.Optional, id = UrlParameter.Optional });

            //Alanlar Kategoriler 
            routes.MapRoute(
               name: "AlanlarKategori",
               url: "HukukiCozumler/{Name}/{id}",
               defaults: new { controller = "SiteBlog", action = "CategoryGetir", Name = UrlParameter.Optional, id = UrlParameter.Optional });


            //anasayfa yazıldgında index gelen static
            routes.MapRoute(
               name: "SiteHome",
               url: "Anasayfa",
               defaults: new { controller = "SiteHome", action = "Index"});

            //iletisim için
            routes.MapRoute(
             name: "Siteiletisim",
             url: "iletisim",
             defaults: new { controller = "SiteHome", action = "Iletisim" });



            ////Kararlar için
            //routes.MapRoute(
            // name: "Kararlars",
            // url: "Kararlar/{title}/{id}",
            // defaults: new { controller = "Kararlar", action = "Index", title = UrlParameter.Optional, id = UrlParameter.Optional });

            //default gelen
            routes.MapRoute(
                 name: "Default",
                 url: "{controller}/{action}/{id}",
                 defaults: new { controller = "SiteHome", action = "Index", id = UrlParameter.Optional }
             );
        }
    }
}
