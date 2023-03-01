using System.Web.Optimization;

namespace Ingemmet.FirmaDocumento.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/jquery-validate/jquery.validate*")
                .Include("~/Scripts/jquery-validate/localization/messages_es.min.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                .Include("~/Scripts/bootstrap.min.js"));

            #endregion

            #region Styles

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.min.css"));

            #endregion

        }
    }
}
