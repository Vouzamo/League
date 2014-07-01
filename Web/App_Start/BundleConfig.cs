using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Global/Styles/Site").Include(
                "~/Content/Site.css")
            );

            bundles.Add(new StyleBundle("~/Global/Styles/Bootstrap").Include(
                "~/Content/bootstrap.min.css")
            );

            bundles.Add(new ScriptBundle("~/Global/Scripts/Modernizr").Include(
                 "~/Scripts/modernizr-{version}.js")
            );

            bundles.Add(new ScriptBundle("~/Global/Scripts/jQuery").Include(
                "~/Scripts/jquery-{version}.js")
            );

            bundles.Add(new ScriptBundle("~/Global/Scripts/jQueryValidate").Include(
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js",
                "~/Scripts/jquery.validate.bootstrap.js")
            );

            bundles.Add(new ScriptBundle("~/Global/Scripts/Bootstrap").Include(
                "~/Scripts/bootstrap.min.js")
            );
        }
    }
}