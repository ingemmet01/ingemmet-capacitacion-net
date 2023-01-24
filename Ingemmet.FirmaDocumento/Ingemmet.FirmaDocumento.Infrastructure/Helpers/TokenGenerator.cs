using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Ingemmet.FirmaDocumento.Infrastructure.Helpers
{
    public static class TokenGenerator
    {
        public const string UserId = "ID_USUARIO";
        public const string UserName = "COD_USUARIO";
        public const string SerialNumber = "certserialnumber";

        /// <summary>
        /// Generar Token.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="expireMinutes"></param>
        /// <param name="userId"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public static string GenerateTokenJwt(string username, int userId, int serialNumber, short expireMinutes = 30)
        {
            // Appsetting for Token JWT
            var secretKey = GetAppSetting("JwtSecretKey");
            //var audienceToken = GetAppSetting("JwtAudienceToken");
            //var issuerToken = GetAppSetting("JwtIssuerToken");
            //var expireTime = GetAppSetting("JwtExpireMinutes");

            //var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));
            var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                new[] {
                    new Claim(UserName, username),
                    new Claim(UserId, userId.ToString()),
                    new Claim(ClaimTypes.SerialNumber, serialNumber.ToString())
                });

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                //audience: audienceToken,
                //issuer: issuerToken,
                subject: claimsIdentity,
                //notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(expireMinutes),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }

        /// <summary>
        /// Validar Token.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static bool ValidateToken(string token)
        {
            // Appsetting for Token JWT
            var secretKey = GetAppSetting("JwtSecretKey");
            //var audienceToken = GetAppSetting("JwtAudienceToken");
            //var issuerToken = GetAppSetting("JwtIssuerToken");

            var securityKey = new SymmetricSecurityKey(Convert.FromBase64String(secretKey));
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    //ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    //ValidIssuer = issuerToken,
                    //ValidAudience = audienceToken,
                    IssuerSigningKey = securityKey
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Obtener claim.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        public static string GetClaim(string token, string claimType)
        {
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var securityToken = tokenHandler.ReadToken(token) as System.IdentityModel.Tokens.Jwt.JwtSecurityToken;
            var stringClaimValue = securityToken.Claims
                .Where(w => w.Type == claimType)
                .Select(c => c.Value)
                .FirstOrDefault();
            return stringClaimValue;
        }

        #region Utilities

        /// <summary>
        /// Obtiene valor de la configuración del web.config
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string GetAppSetting(string key)
            => ConfigurationManager.AppSettings[key].ToString();

        #endregion
    }
}