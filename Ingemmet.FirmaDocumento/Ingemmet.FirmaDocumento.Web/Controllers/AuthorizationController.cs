using Ingemmet.FirmaDocumento.Entity.Models;
using Ingemmet.FirmaDocumento.Infrastructure.Helpers;
using System.Web.Mvc;

namespace Ingemmet.FirmaDocumento.Web.Controllers
{
    [RoutePrefix("authorization")]
    [Route("{action}")]
    public class AuthorizationController : Controller
    {

        [Route("signin")]
        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [Route("signin")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public JsonResult Login(LoginModel model)
        {
            return new JsonCamelCaseResult(null);
        }

        [Authorize]
        [Route("logoff")]
        public ActionResult SignOut(string returnUrl)
        {
            return View();
        }

    }
}