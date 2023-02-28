using System.Web.Optimization;

namespace Ingemmet.FirmaDocumento.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js"));

            #endregion

            #region Styles

            #endregion

        }
    }
}
