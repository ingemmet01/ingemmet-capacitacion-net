using System.ComponentModel.DataAnnotations;

namespace Ingemmet.FirmaDocumento.Infrastructure.Enums
{
    public enum TipoDocumentoEnum
    {
        [Display(Name ="Documento de identidad Nacional")]
        DNI = 120,
        RUC = 2,
        [Display(Name = "Carne de Extranjeria")]
        CE = 3
    }
}
