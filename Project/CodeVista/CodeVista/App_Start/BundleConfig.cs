using System.Web;
using System.Web.Optimization;

namespace CodeVista
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            //Layout Css ve Js

            bundles.Add(new StyleBundle("~/Layout/css").Include(
                     "~/Content/bootstrap.min.css",
                     "~/Content/style.css",
                     "~/Content/responsive.css",
                     "~/Content/jquery.mCustomScrollbar.min.css",
                     "~/Content/deneme.css"));

            bundles.Add(new ScriptBundle("~/Layout/jquery").Include(
                      "~/Scripts/jquery.min.js",
                      "~/Scripts/bootstrap.bundle.min.js",
                      "~/Scripts/popper.min.js",
                      "~/Scripts/jquery-3.0.0.min.js",
                      "~/Scripts/plugin.js",
                      "~/Scripts/jquery.mCustomScrollbar.concat.min.js",
                      "~/Scripts/custom.js"));
        }
    }
}
