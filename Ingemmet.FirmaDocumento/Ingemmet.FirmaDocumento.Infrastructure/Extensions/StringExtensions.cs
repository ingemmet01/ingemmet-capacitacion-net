using System.Globalization;

namespace Ingemmet.FirmaDocumento.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Convertir un <see cref="string"/> a Mayusculas ignorando si el valor es nulo.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToUpperIgnoreNull(this string value)
        {
            if (value != null)            
                value = value.ToUpper(CultureInfo.InvariantCulture);
            
            return value;
        }
    }
}
