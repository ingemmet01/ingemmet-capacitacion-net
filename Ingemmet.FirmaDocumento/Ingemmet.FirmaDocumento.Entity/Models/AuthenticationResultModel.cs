using System;

namespace Ingemmet.FirmaDocumento.Entity.Models
{
    public class AuthenticationResultModel
    {
        public AuthenticationResultModel(string errorMessage = null)
        {
            ErrorMessage = errorMessage;
        }

        public String ErrorMessage { get; private set; }
        public Boolean IsSuccess => String.IsNullOrEmpty(ErrorMessage);
    }
}
