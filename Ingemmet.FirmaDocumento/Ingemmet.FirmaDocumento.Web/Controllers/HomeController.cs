using Ingemmet.CommonService.WebService.Services.Security.Model;
using Ingemmet.FirmaDocumento.Infrastructure.Enums;
using Ingemmet.FirmaDocumento.Infrastructure.Extensions;
using Ingemmet.FirmaDocumento.Infrastructure.Helpers;
using System.Web.Mvc;

namespace Ingemmet.FirmaDocumento.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ActiveDirectoryWebServiceClient client = new ActiveDirectoryWebServiceClient();
            //UserActiveDirectoryResponse response = client.FindByUsername("proyectososi02");
            //client.Close();

            return View();
        }


        public ActionResult Index2()
        {
            TipoDocumentoEnum tipoDocumento = TipoDocumentoEnum.DNI;
            short valorDocumento = (short)tipoDocumento;
            string nameDocumento = tipoDocumento.GetDisplayName();


            return Json(new { Edad = 15, DirOficina = "" });
            //resultado:{ Edad : 15, DirOficina : "" }
        }

        /// <summary>
        /// Registrar tipo documento
        /// </summary>
        /// <param name="tipodocumento"></param>
        /// <returns></returns>
        public ActionResult Registar(string tipodocumento)
        {
            if (tipodocumento.Equals("1")) {
            }
            else if (tipodocumento.Equals("2")){

            }
            else
            {

            }

            bool activo = true;

            if(activo == true) { }


            if (activo)
            {

            }


            string valorA = tipodocumento == null ? "": tipodocumento.ToUpper();        
            string valorB = tipodocumento.ToUpperIgnoreNull();

            TipoDocumentoEnum tipoDocumento =  tipodocumento.ToEnum<TipoDocumentoEnum>();

            switch (tipoDocumento)
            {
                case TipoDocumentoEnum.DNI:
                    break;
                case TipoDocumentoEnum.RUC:
                    break;
                case TipoDocumentoEnum.CE:
                    break;
                default:
                    break;
            }

            return View();
        }


        public ActionResult Index3()
        {
            return new JsonCamelCaseResult(new { Edad = 15, DirOficina = "" },
                //resultado:   {edad:15,dirOficina:""}
                JsonRequestBehavior.AllowGet);
        }
    }
}