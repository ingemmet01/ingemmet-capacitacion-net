using System;
using System.Collections.Generic;
using System.Linq;

namespace Ingemmet.FirmaDocumento.Infrastructure.Helpers
{
    public class RandomHelper
    {
        /// <summary>
        /// Genrear una lista de números y letras
        /// </summary>
        /// <param name="includeLowerCase"></param>
        /// <returns></returns>
        private static List<char> GetAvailableRandomCharacters(bool includeLowerCase)
        {
            var integers = Enumerable.Empty<int>();
            integers = integers.Concat(Enumerable.Range('A', 26));
            integers = integers.Concat(Enumerable.Range('0', 10));

            if (includeLowerCase)
                integers = integers.Concat(Enumerable.Range('a', 26));

            return integers.Select(i => (char)i).ToList();
        }

        /// <summary>
        /// Retorna un código autogenerado de caracteres y digitos.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateAlphanumericCode(int length = 6, bool includeLowerCase = false)
        {
            Random random = new Random();
            var characters = GetAvailableRandomCharacters(includeLowerCase);
            var result = Enumerable.Range(0, length)
                .Select(_ => characters[random.Next(characters.Count)]);

            return string.Concat(result);
        }

        /// <summary>
        /// Retorna un código autogenerado de digitos.
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateDigitCode(int length = 6)
        {
            return new Random().Next(0, int.MaxValue).ToString().Substring(0, length);
        }
    }
}
