using Ingemmet.CommonService.WebService.Services.Security.Model;
using Ingemmet.FirmaDocumento.Entity.Models;
using Microsoft.Owin.Security;
using System;
using System.Net;
using System.Security.Claims;

namespace Ingemmet.FirmaDocumento.Web.Infrastructure.Authorization
{
    public class AuntheticationService
    {
        private readonly IAuthenticationManager _authentificationManager;
        private readonly IActiveDirectoryWebService _activeDirectoryWebService;

        public AuntheticationService(IAuthenticationManager authentificationManager,
            IActiveDirectoryWebService activeDirectoryWebService)
        {
            _authentificationManager = authentificationManager;
            _activeDirectoryWebService = activeDirectoryWebService;
        }

        public AuthenticationResultModel SignIn(string username, string password, bool isPistentent)
        {
            try
            {
                ValidateUserActiveDirectoryResponse userValidate = _activeDirectoryWebService.ValidateCredentials(username, password);

                if (!userValidate.IsValid || userValidate.Status.Code != (short)HttpStatusCode.OK)
                    return new AuthenticationResultModel(userValidate.Status.Message);

                if (userValidate.Data == null)
                    return new AuthenticationResultModel("No se econtro datos del usuario");

                var identity = CreateIdentity(userValidate.Data);
                _authentificationManager.SignOut(AppAuthenticationType.ApplicationCookie);

                if (isPistentent)
                    _authentificationManager.SignIn(new AuthenticationProperties { IsPersistent = true }, identity);
                else
                    _authentificationManager.SignIn(new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1) }, identity);


            }
            catch (Exception ex)
            {
                return new AuthenticationResultModel(ex.Message);
            }

            return new AuthenticationResultModel();
        }

        private ClaimsIdentity CreateIdentity(CommonService.Entity.Models.UserModel data)
        {
            throw new System.NotImplementedException();
        }
    }
}
