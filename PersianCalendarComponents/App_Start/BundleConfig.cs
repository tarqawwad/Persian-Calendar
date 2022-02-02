using System.Web;
using System.Web.Optimization;

namespace PersianCalendarComponents
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                   "~/Scripts/popper.min.js",
                   "~/Scripts/bootstrap.min.js",
                   "~/Scripts/imagesloaded.pkgd.min.js",
                   "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

         
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/style.css",
                      "~/Content/css/bootstrap.min.css", 
                      "~/Content/css/DatePickerCustoms.css"));
        }
    }
}
