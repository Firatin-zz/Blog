using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace BlogApp.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/admin/layout").Include(
                "~/Script/jquery-2.2.3.min.js",
                "~/scripts/bootstrap.min.js",
                "~/scripts/jquery.slimscroll.min.js",
                "~/scripts/fastclick.js",
                "~/scripts/app.min.js",
                "~/scripts/demo.js"
                ));

            //bundles.Add(new StyleBundle("~/bundles/admincss").Include(
            //    "~/Areas/Admin/Content/css/AdminLTE.css",
            //    "~/Areas/Admin/Content/css/_all-skins.min.css"                
            //    ));
            //BundleTable.EnableOptimizations = true;

        }
    }
}