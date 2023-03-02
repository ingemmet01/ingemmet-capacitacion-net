using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Ingemmet.FirmaDocumento.Web.Infrastructure.Authorization
{
    public static class UserClaimsIdentity
    {

        public static string GetUserId => GetClaimsIdentity()
            .Where(w => w.Type == ClaimTypes.NameIdentifier)
            .Select(s => s.Value)
            .FirstOrDefault();

        public static string GetUserLogin => GetClaimsIdentity()
              .Where(w => w.Type == ClaimTypes.WindowsAccountName)
              .Select(s => s.Value)
              .FirstOrDefault();

        public static string GetUserName => HttpContext.Current.User.Identity.Name;

        public static string GetUserEmail => GetClaimsIdentity()
              .Where(w => w.Type == ClaimTypes.Email)
              .Select(s => s.Value)
              .FirstOrDefault();

        public static string GetUserOffice => GetClaimsIdentity()
              .Where(w => w.Type.Equals( "Office"))
              .Select(s => s.Value)
              .FirstOrDefault();


        static IEnumerable<Claim> GetClaimsIdentity()
        {
            var identy = (ClaimsIdentity)HttpContext.Current.User.Identity;
            return identy.Claims;
        }
        
    }
}
