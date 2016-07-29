using System.Web;
using System.Web.Optimization;

namespace RemCua.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/js").Include(
                        "~/Content/Client/js/jquery-1.7.1.min.js",
                        "~/Content/Client/js/jquery.colorbox-min.js",
                        "~/Content/Client/js/cloud-zoom.1.0.2.js",
                        "~/Content/Client/Plugins/Nivo-Slider/jquery.nivo.slider.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Client/Plugins/font-awesome-4.5.0/css/font-awesome.css",
                      "~/Content/Client/Plugins/Nivo-Slider/nivo-slider.css",
                      "~/Content/Client/css/cloud-zoom.css",
                       "~/Content/Client/css/colorbox.css",
                      "~/Content/Client/css/Style.css"));
        }
    }
}
