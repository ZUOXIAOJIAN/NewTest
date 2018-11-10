using System.Web.Optimization;
using NewTest.Core;

namespace NewTest.Web
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapplugin").Include(
                      "~/Scripts/moment-with-locales.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/bootstrap-dialog.js",
                      "~/Scripts/bootstrap-select.js",
                      "~/Scripts/bootstrap-select-zh_CN.js",
                      "~/Scripts/bootstrap-table.js",
                      "~/Scripts/bootstrap-table-zh-CN.js",
                      "~/Scripts/bootstrap-treeview.js",
                      "~/Scripts/jquery.twbsPagination.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrapplugincss").Include(
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/bootstrap-dialog.css",
                      "~/Content/bootstrap-select.css",
                      "~/Content/bootstrap-table.css",
                      "~/Content/bootstrap-treeview.css"));

            bundles.Add(new StyleBundle("~/Content/controlcss").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/StyleControl.css"));
        }
    }
}
