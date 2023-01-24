using System.ComponentModel.DataAnnotations;

namespace Ingemmet.FirmaDocumento.Entity.Models
{
    public class SendCodeByMailModel
    {
        public string User { get; set; }
        public string Message { get; set; }

        [Display(Name = "Código de verificación")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }
    }
}
