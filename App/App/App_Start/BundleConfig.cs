using System.Web;
using System.Web.Optimization;

namespace App
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/vue").Include(
                        "~/Scripts/vue.js"));

            //bundles.Add(new ScriptBundle("~/bundles/pickr", "https://cdn.jsdelivr.net/npm/@simonwep/pickr/dist/pickr.min.js"));
            //bundles.Add(new ScriptBundle("~/bundles/pickr-es5", "https://cdn.jsdelivr.net/npm/@simonwep/pickr/dist/pickr.es5.min.js"));

            //< !--Modern or es5 bundle-- >
            //    < script src = "https://cdn.jsdelivr.net/npm/@simonwep/pickr/dist/pickr.min.js" ></ script >
            //    < script src = "https://cdn.jsdelivr.net/npm/@simonwep/pickr/dist/pickr.es5.min.js" ></ script >

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/pickr/dist/themes/classic", "https://cdn.jsdelivr.net/npm/@simonwep/pickr/dist/themes/classic.min.css"));

            BundleTable.EnableOptimizations = true;
            //< !--One of the following themes -->
            //    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@simonwep/pickr/dist/themes/classic.min.css"/> <!--'classic' theme-->
            //    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@simonwep/pickr/dist/themes/monolith.min.css"/> <!--'monolith' theme-->
            //    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/@simonwep/pickr/dist/themes/nano.min.css"/> <!--'nano' theme-->
        }
    }
}
