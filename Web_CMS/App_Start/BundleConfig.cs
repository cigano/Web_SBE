using System.Web;
using System.Web.Optimization;

namespace Web_CMS
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/methods_pt.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));


            bundles.Add(new StyleBundle("~/Content/CMS/css").Include(
              "~/Content/CMS/css/bootstrap.css",
              "~/Content/CMS/css/plugins/timeline/timeline.css",
              "~/Content/CMS/css/sb-admin.css",
              "~/Content/CMS/font-awesome/css/font-awesome.css",
              "~/Content/CMS/css/Validacao.css"
              ));



            bundles.Add(new ScriptBundle("~/Content/CMS/js").Include(
            "~/Content/CMS/js/jquery-1.10.2.js",
            "~/Content/CMS/js/sb-admin.js",
            "~/Content/CMS/js/plugins/metisMenu/jquery.metisMenu.js",
            "~/Content/CMS/js/bootstrap.min.js",
            "~/Scripts/jquery.unobtrusive-ajax.js",
            "~/Content/CMS/js/plugins/dataTables/jquery.dataTables.js",
            "~/Content/CMS/js/plugins/dataTables/dataTables.bootstrap.js",
            "~/Content/CMS/js/ConfigurarDataTable.js"
            ));



          

        }
    }
}