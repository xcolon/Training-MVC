using System.Web;
using System.Web.Optimization;

namespace ProjectMVC.UI.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                        "~/Scripts/jquery.dataTables.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/moment.js",
                      "~/bootstrap-3.3.5/js/bootstrap.js",
                      "~/Scripts/bootstrap-datetimepicker.min.js",
                       "~/Scripts/kendo.all.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/bootstrap-3.3.5/css/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/StyleSheet.css",
                      "~/Content/kendo.common.min.css",
                      "~/Content/kendo.flat.min.css",
                      "~/Content/jquery.dataTables.css"));
        }
    }
}
