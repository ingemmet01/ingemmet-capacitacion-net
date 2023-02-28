using Ingemmet.FirmaDocumento.Entity.Models;
using Ingemmet.FirmaDocumento.Infrastructure.Helpers;
using System.Web.Mvc;

namespace Ingemmet.FirmaDocumento.Web.Controllers
{
    public class AuthorizationController : Controller
    {
        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public JsonResult Login(LoginModel model)
        {
            return new JsonCamelCaseResult(null);
        }

        [Authorize]
        public ActionResult SignOut(string returnUrl)
        {
            return View();
        }

    }
}