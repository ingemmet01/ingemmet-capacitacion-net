using Ingemmet.FirmaDocumento.Entity.Models;
using Ingemmet.FirmaDocumento.Infrastructure.Helpers;
using Ingemmet.FirmaDocumento.Web.Infrastructure.Authorization;
using Ingemmet.FlujoDocMineral.Entity.Models;
using Microsoft.Owin.Security;
using System;
using System.Net;
using System.Web.Mvc;

namespace Ingemmet.FirmaDocumento.Web.Controllers
{
    [RoutePrefix("authorization")]
    [Route("{action}")]
    public class AuthorizationController : Controller
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IActiveDirectoryWebService _activeDirectoryWebService;

        public AuthorizationController(IAuthenticationManager authenticationManager,
            IActiveDirectoryWebService activeDirectoryWebService)
        {
            _authenticationManager = authenticationManager;
            _activeDirectoryWebService = activeDirectoryWebService;
        }

        [Route("signin")]
        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [Route("signin")]
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual JsonResult Login(LoginModel model)
        {
            var result = new MethodResponseModel<string>(HttpStatusCode.OK, MessageEnum.RedirectingTheAuthenticatedUser);

            try
            {
                var authService = new AuntheticationService(_authenticationManager, _activeDirectoryWebService);
                var auntheticationResult = authService.SignIn(model.Username, model.Password, model.RememberMe);

                if (!auntheticationResult.IsSuccess)
                    return new JsonCamelCaseResult(new MethodResponseModel<string>(HttpStatusCode.NotFound, auntheticationResult.ErrorMessage));

                if (!string.IsNullOrEmpty(model.ReturnUrl))
                    result.Result = model.ReturnUrl;
                else
                    result.Result = Url.Action("Index", "Home");
            }
            catch (Exception ex)
            {
                result = new MethodResponseModel<string>(HttpStatusCode.InternalServerError, ex.Message);
            }

            return new JsonCamelCaseResult(result);
        }

        [Authorize]
        [Route("logoff")]
        public ActionResult SignOut(string returnUrl)
        {
            _authenticationManager.SignOut(AppAuthenticationType.ApplicationCookie);
            return RedirectToAction("Login", "Authorization", new { returnUrl = returnUrl });
        }

    }
}