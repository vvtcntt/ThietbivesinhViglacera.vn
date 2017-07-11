using System.Web;
using System.Web.Optimization;

namespace Viglacera
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
                        "~/Scripts/jquery.validate*"));

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
            bundles.Add(new StyleBundle("~/Content/Display/Css/Style").Include(
                   "~/Content/Display/Css/Default.css",
                   "~/Content/Display/Css/Default_Res.css",
                   "~/Content/Display/Css/News.css",
                   "~/Content/Display/Css/News_Res.css",
                   "~/Content/Display/Css/nivo-slider.css",
                   "~/Content/Display/Css/Order.css",
                   "~/Content/Display/Css/Order_res.css",
                   "~/Content/Display/Css/Product.css",
                   "~/Content/Display/Css/Product_Res.css",
                   "~/Content/Display/Css/style.css",
                   "~/Content/Display/Css/jquery.mmenu.all.css",
                   "~/Content/Display/Css/demo.css",
                   "~/Content/PagedList.css",
                   "~/Content/Display/Css/Slide.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}